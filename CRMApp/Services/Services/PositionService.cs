using AutoMapper;
using Domain.Common.Constants;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Position;
using Domain.Common.Exceptions;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _repo;
        private readonly IMapper _mapper;
        public PositionService(IPositionRepository repo,
                               IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(PositionCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            if (!await _repo.CheckByName(model.Name))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }

            model.Name = String.Concat(model.Name[0].ToString().ToUpper()) + model.Name[1..].ToLower();
            await _repo.CreateAsync(_mapper.Map<Position>(model));
        }

        public async Task<IEnumerable<PositionDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PositionDto>>(await _repo.GetAllAsync());
        }

        public async Task<PositionDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            return _mapper.Map<PositionDto>(await _repo.GetByIdAsync(id));
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Position existPosition = await _repo.GetByIdAsync(id);
            await _repo.SoftDeleteAsync(existPosition);
        }

        public async Task UpdateAsync(int? id, PositionUpdateDto model)
        {
            if (id is null || model is null) throw new ArgumentNullException(ExceptionResponseMessages.ParametrNotFoundMessage);

            Position existPosition = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            if (!await _repo.CheckByName(model.Name))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }

            model.Name = String.Concat(model.Name[0].ToString().ToUpper()) + model.Name[1..].ToLower();
            _mapper.Map(model, existPosition);
            await _repo.UpdateAsync(existPosition);
        }
    }
}
