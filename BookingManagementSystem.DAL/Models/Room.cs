using BookingManagementSystem.DAL.Configurations;
using BookingManagementSystem.DAL.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.DAL.Models
{
    [EntityTypeConfiguration(typeof(RoomConfiguration))]
    public class Room : BaseEntity
    {
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public RoomType Type { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
