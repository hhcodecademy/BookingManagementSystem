using AutoMapper;
using BookingManagementSystem.BLL.Services.Interface;
using BookingManagementSystem.DAL.Dtos;
using BookingManagementSystem.DAL.Models;
using BookingManagementSystem.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.BLL.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto>
        where TEntity : BaseEntity, new()
        where TDto : BaseDto, new()
    {
        protected readonly IMapper _mapper;
        protected readonly IGenericRepository<TEntity> _repository;

        public GenericService(IMapper mapper, IGenericRepository<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<TDto> Add(TDto dto)
        {
            var entityToCreate = _mapper.Map<TEntity>(dto);

            var createdEntity = await _repository.Add(entityToCreate);

            return _mapper.Map<TDto>(createdEntity);
        }

        public async Task<TDto> Get(Guid id)
        {
            var entity = await _repository.Get(id);
            var dto = _mapper.Map<TDto>(entity);
            return dto;
        }

        public async Task<List<TDto>> GetAll()
        {
            var query = await _repository.GetAll();
            var entities = query.ToList();
            var dtos = _mapper.Map<List<TDto>>(entities);
            return dtos;
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        public async Task<TDto> Update(TDto dto)
        {
            var entityToUpdate = await _repository.Get(dto.Id);

            entityToUpdate = _mapper.Map<TEntity>(dto);

            _repository.Update(entityToUpdate);

            var updatedDto = _mapper.Map<TDto>(entityToUpdate);

            return updatedDto;
        }
    }
}
