using BookingManagementSystem.BLL.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BookingManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly IWebHostEnvironment _environment;

        public DocumentsController(IDocumentService documentService, IWebHostEnvironment environment)
        {
            _documentService = documentService;
            _environment = environment;
        }
        [HttpGet]
        public async Task<IActionResult> Download(string name)
        {
            var document =await _documentService.DownloadDocumentByName(name);
            var localPath = Path.Combine(_environment.ContentRootPath, document.Path);

            var fs = new FileStream(localPath, FileMode.Open);

            return File(fs, "image/jpeg", document.OriginName);
        }
    }
}
