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
            IEnumerable<Position> existPositions = await _repo.GetAllWithIncludes(p => p.StaffPositions);
            IEnumerable<PositionDto> mappedDatas = _mapper.Map<IEnumerable<PositionDto>>(existPositions);

            foreach (var data in mappedDatas)
            {
                Position position = existPositions.Where(g => g.Id == data.Id).FirstOrDefault();

                foreach (var teacherGroup in position.StaffPositions)
                {
                    data.StaffIds.Add(teacherGroup.StaffId);
                }
                data.StaffCount = position.StaffPositions.Count;
            }


            return mappedDatas;
        }

        public async Task<PositionDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            IEnumerable<Position> existPositions = await _repo.GetAllWithIncludes(p => p.StaffPositions);

            Position existPosition = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            PositionDto mappedData = _mapper.Map<PositionDto>(existPosition);

            foreach (var staffPosition in existPosition.StaffPositions)
            {
                mappedData.StaffIds.Add(staffPosition.StaffId);
            }

            return mappedData;
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
          
            Position existPosition = await _repo.GetByIdAsync(id) 
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
           
            await _repo.SoftDeleteAsync(existPosition);
        }

        public async Task UpdateAsync(int? id, PositionUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            Position existPosition = await _repo.GetByIdAsync(id) 
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

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
