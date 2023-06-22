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
        private readonly IMapper _mapper;
        public StaffService(IStaffRepository repo,
                            IMapper mapper,
                            IStaffPositionRepository staffPositionRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _staffPositionRepo = staffPositionRepo;
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
                StaffPosition staffPosition = new()
                {
                    PositionId = positionId
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
                Staff staff = existStaff.FirstOrDefault(m => m.Id == data.Id);

                if (staff is not null)
                {
                    data.Images.Add(Convert.ToBase64String(staff.Image));

                    foreach (var item in staff.StaffPositions)
                    {
                        data.PositionIds.Add(item.PositionId);
                    }
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

            foreach (var item in staffPositionByStaffId)
            {
                mappedData.PositionIds.Add(item.PositionId);
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
          
            if (!await _repo.CheckByEmail(model.Email))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }

            foreach (var positionId in model.PositionIds)
            {
                StaffPosition staffPosition = new()
                {
                    PositionId = positionId
                }; 

                foreach (var item in staffPositionByStaffId)
                {
                    _staffPositionRepo.DeleteAsync(item);
                }

                staffPositionByStaffId.Add(staffPosition);
            }

            Staff mappedData = _mapper.Map(model, existStaff);

            if (model.Photo is not null)
                mappedData.Image = await model.Photo.GetBytes();

            mappedData.StaffPositions = staffPositionByStaffId;

            await _repo.UpdateAsync(mappedData);
        }
    }
}
