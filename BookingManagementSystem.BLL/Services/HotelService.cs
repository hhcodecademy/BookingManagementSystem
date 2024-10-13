using AutoMapper;
using BookingManagementSystem.BLL.Services.Interface;
using BookingManagementSystem.DAL.Dtos;
using BookingManagementSystem.DAL.Models;
using BookingManagementSystem.DAL.Repository;
using BookingManagementSystem.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagementSystem.BLL.Services
{
    public class HotelService : IHotelService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Hotel> _repository;
        private readonly IDocumentRepository _documentRepository;

        public HotelService(IMapper mapper, IGenericRepository<Hotel> repository, IDocumentRepository documentRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _documentRepository = documentRepository;
        }
        public async Task<HotelDto> Add(HotelDto dto, Document document)
        {
            var entityToCreate = _mapper.Map<Hotel>(dto);

            entityToCreate.ThumbnailUrl = document.Path;

            var createdEntity = await _repository.Add(entityToCreate);

            document.OwnerId = createdEntity.Id;
            await _documentRepository.Add(document);

            return _mapper.Map<HotelDto>(createdEntity);
        }

        public async Task<HotelDto> Get(Guid id)
        {
            var entity = await _repository.Get(id);
            var dto = _mapper.Map<HotelDto>(entity);
            return dto;
        }

        public async Task<List<HotelDto>> GetAll()
        {
            var query = await _repository.GetAll();
            var entities = query.ToList();
            var dtos = _mapper.Map<List<HotelDto>>(entities);
            return dtos;
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        public async Task<HotelDto> Update(HotelDto dto)
        {
            var entityToUpdate = await _repository.Get(dto.Id);

            entityToUpdate = _mapper.Map<Hotel>(dto);

            _repository.Update(entityToUpdate);

            var updatedDto = _mapper.Map<HotelDto>(entityToUpdate);

            return updatedDto;
        }
    }
}
