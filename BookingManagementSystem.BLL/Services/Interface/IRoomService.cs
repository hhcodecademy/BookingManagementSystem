using BookingManagementSystem.DAL.Dtos;
using BookingManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.BLL.Services.Interface
{
    public interface IRoomService : IGenericService<Room, RoomDto>
    {
        public Task<RoomDto> AddWithImages(RoomDto roomDto, List<Document> documents);
        public Task<RoomDto> GetWithImages(Guid Id);
    }
}
