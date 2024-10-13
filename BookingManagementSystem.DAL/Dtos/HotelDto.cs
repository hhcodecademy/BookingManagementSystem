using BookingManagementSystem.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.DAL.Dtos
{
    public class HotelDto : BaseDto
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }

    }
}
