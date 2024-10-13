using AutoMapper;
using BookingManagementSystem.DAL.Dtos;
using BookingManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.BLL.MapProfile
{
    public class CustomProfile:Profile
    {
        public CustomProfile()
        {
           CreateMap<HotelDto, Hotel>().ReverseMap();
           CreateMap<RoomDto, Room>().ReverseMap();
           CreateMap<DocumentDto, Document>().ReverseMap();
        }
    }
}
