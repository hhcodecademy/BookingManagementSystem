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
    public class RoomService : GenericService<Room, RoomDto>, IRoomService
    {
        private readonly IDocumentRepository _documentRepository;

        public RoomService(IMapper mapper, IGenericRepository<Room> repository, IDocumentRepository documentRepository) : base(mapper, repository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<RoomDto> AddWithImages(RoomDto roomDto, List<Document> documents)
        {
            var entityToCreate = _mapper.Map<Room>(roomDto);
            var createdEntity = await _repository.Add(entityToCreate);

            foreach (var item in documents)
            {

                item.OwnerId = createdEntity.Id;
                await _documentRepository.Add(item);

            }

            return _mapper.Map<RoomDto>(createdEntity);
        }

        public async Task<RoomDto> GetWithImages(Guid id)
        {
            var entity = await Get(id);

            var documents = await _documentRepository.GetDocumentsByOwnerId(id);

            entity.Images = documents.Select(d => d.FileName).ToList();

            return entity;
        }
    }
}
