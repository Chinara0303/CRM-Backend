using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Room;
using Services.Services.İnterfaces;
using Domain.Common.Exceptions;
using AutoMapper;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Domain.Common.Constants;
using Services.DTOs.Education;
using Org.BouncyCastle.Crypto;

namespace Services.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repo;
        private readonly IGroupRepository _groupRepo;
        private readonly IMapper _mapper;
        public RoomService(IRoomRepository repo,
                           IMapper mapper,
                           IGroupRepository groupRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _groupRepo = groupRepo;
        }

        public async Task CreateAsync(RoomCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);
            
            if (!await _repo.CheckByName(model.Name))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }

            model.Name = String.Concat(model.Name[0].ToString().ToUpper()) + model.Name[1..].ToLower();
            await _repo.CreateAsync(_mapper.Map<Room>(model));
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            IEnumerable<Room> rooms = await _repo.GetAllWithIncludes(m => m.Groups);
            IEnumerable<RoomDto> mappedDatas = _mapper.Map<IEnumerable<RoomDto>>(rooms);

            foreach (var item in mappedDatas)
            {
                Room room = rooms.FirstOrDefault(m => m.Id == item.Id);

                if (room is not null)
                {
                    foreach (var group in room.Groups)
                    {
                        item.GroupIds.Add(item.Id);
                    }
                }
                item.GroupCount = room.Groups.Count;
            }
            return mappedDatas;
        }

        public async Task<RoomDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            var existRoom = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            
            IEnumerable<Group> existGroups = await _groupRepo.GetAllAsync();
            IEnumerable<Group> groupsByRoomId = existGroups
                                            .Where(m => m.RoomId == existRoom.Id)
                                            .ToList();
         
            RoomDto mappedData = _mapper.Map<RoomDto>(existRoom);

            foreach (var item in groupsByRoomId)
            {
                mappedData.GroupIds.Add(item.Id);
            }
          
            mappedData.GroupCount = groupsByRoomId.Count();
            return mappedData;
        }

        public async Task SoftDeleteAsync(int? id)

        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Room existRoom = await _repo.GetByIdAsync(id);
            await _repo.SoftDeleteAsync(existRoom);
        }

        public async Task UpdateAsync(int? id, RoomUpdateDto model)
        {
           ArgumentNullException.ThrowIfNull(id,ExceptionResponseMessages.ParametrNotFoundMessage);
           ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            Room existRoom = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            if (!await _repo.CheckByName(model.Name))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }

            model.Name = String.Concat(model.Name[0].ToString().ToUpper()) + model.Name[1..].ToLower();
            _mapper.Map(model, existRoom);
            await _repo.UpdateAsync(existRoom);
        }
    }
}
