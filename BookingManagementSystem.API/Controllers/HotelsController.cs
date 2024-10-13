using BookingManagementSystem.API.Extensions;
using BookingManagementSystem.BLL.Services.Interface;
using BookingManagementSystem.DAL.Dtos;
using BookingManagementSystem.DAL.Enums;
using BookingManagementSystem.DAL.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BookingManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly ILogger<HotelsController> _logger;
        private readonly IValidator<HotelDto> _validator;

        private readonly IWebHostEnvironment _environment;


        public HotelsController(IHotelService hotelService, ILogger<HotelsController> logger, IValidator<HotelDto> validator, IWebHostEnvironment environment)
        {
            _hotelService = hotelService;
            _logger = logger;
            _validator = validator;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hotels = await _hotelService.GetAll();
            var jsonHotels = JsonSerializer.Serialize(hotels);
            _logger.LogInformation(jsonHotels);
            return Ok(hotels);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var hotel = await _hotelService.Get(Id);
            return Ok(hotel);
        }
        [HttpPost]
        public async Task<IActionResult> Post(HotelDto dto)
        {
            var localPath = _environment.ContentRootPath;
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.File.FileName);
            var directoryPath = Path.Combine("Documents", "Hotels", fileName);
            var fullPath = Path.Combine(localPath, directoryPath);

            using (var fs = new FileStream(fullPath, FileMode.Create))
            {
                await dto.File.CopyToAsync(fs);

            }

            var document = new Document
            {
                FileName = fileName,
                OriginName = dto.File.FileName,
                Path = directoryPath,
                DocumentType = DocumentType.Hotel,
            };

            var result = await _validator.ValidateAsync(dto);

            if (result.IsValid)
            {
                var res = await _hotelService.Add(dto, document);
                return Ok(res);
            }
            result.AddToModelState(ModelState);
            return Ok(dto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid Id, HotelDto dto)
        {
            var res = await _hotelService.Get(Id);
            if (res == null)
            {
                return NotFound();
            }
            var updatRes = await _hotelService.Update(dto);
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
                _hotelService.Remove(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }

            return Ok();
        }
    }
}
