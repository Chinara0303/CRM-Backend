using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Position;
using Services.DTOs.Social;
using Services.Services.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SocialService : ISocialService
    {
        private readonly ISocialRepository _repo;
        private readonly IMapper _mapper;
        public SocialService(ISocialRepository repo,
                            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(SocialCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            await _repo.CreateAsync(_mapper.Map<Social>(model));
        }

        public async Task<IEnumerable<SocialDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<SocialDto>>(await _repo.GetAllAsync());
        }

        public async Task<SocialDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            return _mapper.Map<SocialDto>(await _repo.GetByIdAsync(id));
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Social existSocial = await _repo.GetByIdAsync(id);
            await _repo.SoftDeleteAsync(existSocial);
        }

        public async Task UpdateAsync(int? id, SocialUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            Social existSocial = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            _mapper.Map(model, existSocial);
            await _repo.UpdateAsync(existSocial);
        }
    }
}
