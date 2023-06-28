using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Staff;
using Services.Helpers.Extentions;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _repo;
        private readonly IStaffPositionRepository _staffPositionRepo;
        private readonly IPositionRepository _positionRepo;
        private readonly IMapper _mapper;
        public StaffService(IStaffRepository repo,
                            IMapper mapper,
                            IStaffPositionRepository staffPositionRepo,
                            IPositionRepository positionRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _staffPositionRepo = staffPositionRepo;
            _positionRepo = positionRepo;
        }
        public async Task CreateAsync(StaffCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);
            Staff mappedData = _mapper.Map<Staff>(model);

            List<StaffPosition> staffPositions = new();


            if (!await _repo.CheckByEmail(model.Email))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }

            foreach (var positionId in model.PositionIds)
            {
                Position position = await _positionRepo.GetByIdAsync(positionId)
                  ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                StaffPosition staffPosition = new()
                {
                    Position = position,
                    Staff = mappedData
                };

                staffPositions.Add(staffPosition);
            }

            mappedData.StaffPositions = staffPositions;

            mappedData.Image = await model.Photo.GetBytes();

            await _repo.CreateAsync(mappedData);
        }

        public async Task<IEnumerable<StaffListDto>> GetAllAsync()
        {
            IEnumerable<Staff> existStaff = await _repo.GetAllWithIncludes(e => e.StaffPositions);

            IEnumerable<StaffListDto> mappedDatas = _mapper.Map<IEnumerable<StaffListDto>>(existStaff);

            foreach (var data in mappedDatas)
            {
                Staff staff = existStaff.FirstOrDefault(m => m.Id == data.Id)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                List<string> images = new();
                List<int> positionIds = new();

                images.Add(Convert.ToBase64String(staff.Image));
                data.Image = images;

                foreach (var item in staff.StaffPositions)
                {
                    positionIds.Add(item.PositionId);
                    data.PositionIds = positionIds;
                }
            }
            return mappedDatas;
        }

        public async Task<StaffDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);

            Staff existStaff = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            IEnumerable<StaffPosition> existStaffPosition = await _staffPositionRepo.GetAllAsync();

            List<StaffPosition> staffPositionByStaffId = existStaffPosition
                                    .Where(e => e.StaffId == existStaff.Id)
                                    .ToList();

            StaffDto mappedData = _mapper.Map<StaffDto>(existStaff);

            List<int> positionIds = new();

            foreach (var item in staffPositionByStaffId)
            {
                positionIds.Add(item.PositionId);
                mappedData.PositionIds = positionIds;
            }

            mappedData.Image = Convert.ToBase64String(existStaff.Image);

            return mappedData;
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);

            Staff existStaff = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            await _repo.SoftDeleteAsync(existStaff);
        }

        public async Task UpdateAsync(int? id, StaffUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            Staff existStaff = await _repo.GetByIdAsync(id)
              ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            IEnumerable<StaffPosition> existStaffPosition = await _staffPositionRepo.GetAllAsync();

            List<StaffPosition> staffPositionByStaffId = existStaffPosition
                               .Where(e => e.StaffId == existStaff.Id)
                               .ToList();


            List<StaffPosition> staffPositions = new();

            foreach (var positionId in model.PositionIds)
            {
                Position position = await _positionRepo.GetByIdAsync(positionId)
                         ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                StaffPosition staffPosition = new()
                {
                    PositionId = positionId,
                    StaffId = existStaff.Id
                };

                staffPositions.Add(staffPosition);
            }
            existStaff.StaffPositions = staffPositions;

            Staff mappedData = _mapper.Map(model, existStaff);

            if (model.Photo is not null)
                mappedData.Image = await model.Photo.GetBytes();

            await _repo.UpdateAsync(mappedData);
        }
    }
}
