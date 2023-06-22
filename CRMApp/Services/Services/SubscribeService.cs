using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Subscribe;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class SubscribeService : ISubscribeService
    {
        private readonly ISubscribeRepository _repo;
        private readonly IMapper _mapper;
        public SubscribeService(ISubscribeRepository repo,
                                IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(SubscribeCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);
            
            if (!await _repo.CheckByEmail(model.Email))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }

            await _repo.CreateAsync(_mapper.Map<Subscribe>(model));
        }

        public async Task<IEnumerable<SubscribeDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<SubscribeDto>>(await _repo.GetAllAsync());
        }

        public async Task<SubscribeDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            return _mapper.Map<SubscribeDto>(await _repo.GetByIdAsync(id));
        }

        public async Task SoftDeleteAsync(int? id)
        {

            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
           
            Subscribe existSubscribe = await _repo.GetByIdAsync(id) 
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            
            await _repo.SoftDeleteAsync(existSubscribe);
        }

       
    }
}
