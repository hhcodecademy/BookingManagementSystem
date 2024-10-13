using BookingManagementSystem.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.DAL.Dtos
{
    public class BookingDto:BaseDto
    {
        public Guid CustomerId { get; set; }
        public Guid RoomId { get; set; }
    }
}
