using BookingManagementSystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.DAL.Dtos
{
    public class DocumentDto:BaseDto
    {
        public DocumentType DocumentType { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string OriginName { get; set; }
    }
}
