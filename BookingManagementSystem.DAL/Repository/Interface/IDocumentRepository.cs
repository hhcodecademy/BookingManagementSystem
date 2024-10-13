using BookingManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.DAL.Repository.Interface
{
    public interface IDocumentRepository : IGenericRepository<Document>
    {
        Task<List<Document>> GetDocumentsByOwnerId(Guid ownerId);
        Task<Document> GetDocumentByName(string name);
    }
}
