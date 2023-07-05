using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.SiteSocial;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class SiteSociaService : ISiteSocialService
    {
        private readonly ISiteSocialRepository _repo;
        private readonly IMapper _mapper;
        public SiteSociaService(ISiteSocialRepository repo,
                                IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(SiteSocialCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            await _repo.CreateAsync(_mapper.Map<SiteSocial>(model));
        }

        public async Task<IEnumerable<SiteSocialDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<SiteSocialDto>>(await _repo.GetAllAsync());
        }

        public async Task<SiteSocialDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            return _mapper.Map<SiteSocialDto>(await _repo.GetByIdAsync(id));
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);

            SiteSocial existSocial = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            await _repo.SoftDeleteAsync(existSocial);
        }

        public async Task UpdateAsync(int? id, SiteSocialUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            SiteSocial existSocial = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            _mapper.Map(model, existSocial);
            await _repo.UpdateAsync(existSocial);
        }
    }
}
