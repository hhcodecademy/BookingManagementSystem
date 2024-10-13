using BookingManagementSystem.DAL.Data;
using BookingManagementSystem.DAL.Models;
using BookingManagementSystem.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.DAL.Repository
{
    public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Document> GetDocumentByName(string name)
        {
            var document = _dbContext.Documents.Where(f => f.FileName == name).FirstOrDefault();
            return document;
        }

        public async Task<List<Document>> GetDocumentsByOwnerId(Guid ownerId)
        {
            var documents = _dbContext.Documents.Where(d => d.OwnerId == ownerId);
           
            if (documents.Any())
            {
                return await documents.ToListAsync();
            }

            return null;
        }
    }
}
