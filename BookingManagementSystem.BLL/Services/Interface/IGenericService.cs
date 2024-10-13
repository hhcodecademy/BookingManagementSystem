using BookingManagementSystem.DAL.Dtos;
using BookingManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.BLL.Services.Interface
{
    public interface IGenericService<TEntity, TDto> where TEntity : BaseEntity, new()
        where TDto : BaseDto, new()
    {
        public Task<TDto> Add(TDto dto);
        public Task<TDto> Update(TDto dto);
        public Task<TDto> Get(Guid id);
        public Task<List<TDto>> GetAll();
        public void Remove(Guid id);
    }
}