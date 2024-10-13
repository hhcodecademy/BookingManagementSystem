using BookingManagementSystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.DAL.Models
{
    public class Document : BaseEntity
    {
        public DocumentType DocumentType { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string OriginName { get; set; }
        public Guid OwnerId { get; set; }
    }
}
