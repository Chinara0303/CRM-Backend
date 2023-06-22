using AutoMapper;
using Domain.Common.Constants;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Position;
using Domain.Common.Exceptions;
using Services.Services.İnterfaces;
using Services.DTOs.Group;

namespace Services.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _repo;
        private readonly IStaffPositionRepository _staffRepository;
        private readonly IMapper _mapper;
        public PositionService(IPositionRepository repo,
                               IMapper mapper,
                               IStaffPositionRepository staffRepository)
        {
            _repo = repo;
            _mapper = mapper;
            _staffRepository = staffRepository;
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
            IEnumerable<PositionDto> mappedDatas = _mapper.Map<IEnumerable<PositionDto>>(await _repo.GetAllAsync());

            //IEnumerable<StaffPosition> existStaffPosition = await _staffRepository.GetAllAsync();

            //foreach (var data in mappedDatas)
            //{
            //    foreach (var staffPosition in existStaff.FirstOrDefault().StaffPositions)
            //    {
            //        staff staff = existStaff.Where(m => m.Id == staffPosition.StaffId).FirstOrDefault()
            //            ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            //        foreach (var item in staff.StaffPositions)
            //        {
            //            data.StaffIds.Add(item.StaffId);
            //        }
            //    }
            //}


            return mappedDatas;
        }

        public async Task<PositionDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            return _mapper.Map<PositionDto>(await _repo.GetByIdAsync(id));
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Position existPosition = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            await _repo.SoftDeleteAsync(existPosition);
        }

        public async Task UpdateAsync(int? id, PositionUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

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
