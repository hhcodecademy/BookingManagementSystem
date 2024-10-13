using BookingManagementSystem.DAL.Dtos;
using BookingManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.BLL.Services.Interface
{
    public interface IDocumentService: IGenericService<Document, DocumentDto>
    {
        Task<DocumentDto> DownloadDocumentByName(string name);
    }
}
