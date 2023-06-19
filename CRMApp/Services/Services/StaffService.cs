using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Staff;
using Services.DTOs.Student;
using Services.Helpers.Extentions;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _repo;
        private readonly IMapper _mapper;
        public StaffService(IStaffRepository repo,
                            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(StaffCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            if (!await _repo.CheckByEmail(model.Email))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }

            Staff mappedData = _mapper.Map<Staff>(model);
            mappedData.Image = await model.Photo.GetBytes();

            await _repo.CreateAsync(mappedData);
        }

        public async Task<IEnumerable<StaffListDto>> GetAllAsync()
        {
            IEnumerable<Staff> existStaff = await _repo.GetAllAsync();

            IEnumerable<StaffListDto> mappedDatas = _mapper.Map<IEnumerable<StaffListDto>>(existStaff);

            foreach (var data in mappedDatas)
            {
                Staff staff = existStaff.FirstOrDefault(m => m.Id == data.Id);

                if (staff is not null)
                {
                    List<string> images = new();
                    images.Add(Convert.ToBase64String(staff.Image));
                    data.Images = images;
                }
            }
            return mappedDatas;
        }

        public async Task<StaffDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Staff existStaff = await _repo.GetByIdAsync(id);
            var mappedData = _mapper.Map<StaffDto>(existStaff);

            mappedData.Image = Convert.ToBase64String(existStaff.Image);
            return mappedData;
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Staff existStaff = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            await _repo.SoftDeleteAsync(existStaff);
        }

        public async Task UpdateAsync(int? id, StaffUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            if (!await _repo.CheckByEmail(model.Email))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }

            Staff existStaff = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            Staff mappedData = _mapper.Map(model, existStaff);
            if (model.Photo is not null)
                mappedData.Image = await model.Photo.GetBytes();

            await _repo.UpdateAsync(mappedData);
        }
    }
}
