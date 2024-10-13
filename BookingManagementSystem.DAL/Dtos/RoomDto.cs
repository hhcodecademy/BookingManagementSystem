using BookingManagementSystem.DAL.Dtos;
using BookingManagementSystem.DAL.Enum;
using BookingManagementSystem.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.DAL.Dtos
{
    public class RoomDto:BaseDto
    {
        public int RoomNumber { get; set; }
        public Guid HotelId { get; set; }
        public RoomType Type { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<string> Images { get; set; }
    }
}
