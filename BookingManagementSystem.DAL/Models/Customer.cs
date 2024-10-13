using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.DAL.Models
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; } 
        public string Surname { get; set; } 
        public string Email { get; set; } 
        public string PhoneNumber { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
