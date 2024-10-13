using BookingManagementSystem.BLL.Services.Interface;
using BookingManagementSystem.DAL.Dtos;
using BookingManagementSystem.DAL.Enums;
using BookingManagementSystem.DAL.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookingManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;

        private readonly IWebHostEnvironment _environment;

        public RoomsController(IRoomService roomService, IWebHostEnvironment environment)
        {
            _roomService = roomService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomService.GetAll();
            return Ok(rooms);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var room = await _roomService.Get(Id);
            return Ok(room);
        }

        [HttpGet("documents/{id}")]
        public async Task<IActionResult> GetWithDocuments(Guid id)
        {
            var room = await _roomService.GetWithImages(id);
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RoomDto dto)
        {
            var localPath = _environment.ContentRootPath;


            var documents = new List<Document>();

            foreach (var file in dto.Files)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var directoryPath = Path.Combine("Documents", "Rooms", fileName);
                var fullPath = Path.Combine(localPath, directoryPath);

                using (var fs = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }

                documents.Add(new Document
                {
                    FileName = fileName,
                    OriginName = file.FileName,
                    Path = directoryPath,
                    DocumentType = DocumentType.Room,
                });
            }

            var res = await _roomService.AddWithImages(dto, documents);

            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid Id, RoomDto dto)
        {
            var res = await _roomService.Get(Id);
            if (res == null)
            {
                return NotFound();
            }
            var updatRes = await _roomService.Update(dto);
            return Ok(updatRes);
        }
        /*    [HttpDelete]
            public async Task<IActionResult> Delete(Guid Id)
            {
                var res = await _hotelService.Get(Id);
                if(res == null)
                {
                    return NotFound();
                }
                  _hotelService.Remove(Id);
                return Ok();
            }*/
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                _roomService.Remove(Id);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
