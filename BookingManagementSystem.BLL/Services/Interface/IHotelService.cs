using BookingManagementSystem.DAL.Dtos;
using BookingManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.BLL.Services.Interface
{
    public interface IHotelService
    {
        public Task<HotelDto> Add(HotelDto hotel, Document document);
        public Task<HotelDto> Update(HotelDto hotel);
        public Task<HotelDto> Get(Guid id);
        public Task<List<HotelDto>> GetAll();
        public void Remove(Guid id);
    }
}
