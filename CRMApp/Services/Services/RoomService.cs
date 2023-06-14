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

namespace Services.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repo;
        private readonly IMapper _mapper;
        public RoomService(IRoomRepository repo,
                           IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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

        public async Task<IEnumerable<RoomDto>> GetAllAsync() => _mapper.Map<IEnumerable<RoomDto>>(await _repo.GetAllAsync());

        public async Task<RoomDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            return _mapper.Map<RoomDto>(await _repo.GetByIdAsync(id));
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Room existRoom = await _repo.GetByIdAsync(id);
            await _repo.SoftDeleteAsync(existRoom);
        }

        public async Task UpdateAsync(int? id, RoomUpdateDto model)
        {
            if (id is null || model is null) throw new ArgumentNullException(ExceptionResponseMessages.ParametrNotFoundMessage);

            Room existRoom = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

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
