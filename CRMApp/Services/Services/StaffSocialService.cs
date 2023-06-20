using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Social;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class StaffSocialService : IStaffSocialService
    {
        private readonly IStaffSocialRepository _repo;
        private readonly IStaffRepository _staffRepo;
        private readonly IMapper _mapper;
        public StaffSocialService(IStaffSocialRepository repo,
                                  IMapper mapper,
                                  IStaffRepository staffRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _staffRepo = staffRepo;
        }
        public async Task CreateAsync(StaffSocialCreateDto model)
        {

            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);
            _ = await _staffRepo.GetByIdAsync(model.StaffId)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            await _repo.CreateAsync(_mapper.Map<StaffSocial>(model));
        }

        public async Task<IEnumerable<StaffSocialDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<StaffSocialDto>>(await _repo.GetAllWithIncludes(s=>s.Staff));
        }

        public async Task<StaffSocialDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            return _mapper.Map<StaffSocialDto>(await _repo.GetByIdAsync(id));
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            StaffSocial existSocial = await _repo.GetByIdAsync(id) 
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            await _repo.SoftDeleteAsync(existSocial);
        }

        public async Task UpdateAsync(int? id, StaffSocialUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            StaffSocial existSocial = await _repo.GetByIdAsync(id) 
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            _ = await _staffRepo.GetByIdAsync(model.StaffId)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
           
            _mapper.Map(model, existSocial);
            await _repo.UpdateAsync(existSocial);
        }
    }
}
