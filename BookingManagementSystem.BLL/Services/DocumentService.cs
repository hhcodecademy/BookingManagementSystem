using AutoMapper;
using BookingManagementSystem.BLL.Services.Interface;
using BookingManagementSystem.DAL.Dtos;
using BookingManagementSystem.DAL.Models;
using BookingManagementSystem.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.BLL.Services
{
    public class DocumentService : GenericService<Document, DocumentDto>, IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IMapper mapper, IDocumentRepository documentRepository) : base(mapper, documentRepository)
        {
            _documentRepository = documentRepository;
        }


        public async Task<DocumentDto> DownloadDocumentByName(string name)
        {
            var document = await _documentRepository.GetDocumentByName(name);

           return _mapper.Map<DocumentDto>(document);
        }
    }
}
