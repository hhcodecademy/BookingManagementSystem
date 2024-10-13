using BookingManagementSystem.DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.DAL.Models
{
    [EntityTypeConfiguration(typeof(HotelConfiguration))]
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
