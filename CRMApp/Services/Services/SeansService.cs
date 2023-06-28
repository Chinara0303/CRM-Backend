using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Seans;
using Services.DTOs.Time;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class SeansService : ISeansService
    {
        private readonly ISeansRepository _repo;
        private readonly IMapper _mapper;
        public SeansService(ISeansRepository repo,
                            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public  async Task CreateAsync(SeansCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            await _repo.CreateAsync(_mapper.Map<Seans>(model));
        }

        public async Task<IEnumerable<SeansDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<SeansDto>>(await _repo.GetAllAsync());
        }

        public async Task<SeansDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
           
            Seans existSeans = await _repo.GetByIdAsync(id);

            return existSeans is null ? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage) : _mapper.Map<SeansDto>(existSeans);
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Seans existSeans = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            await _repo.SoftDeleteAsync(existSeans);
        }

        public async Task UpdateAsync(int? id, SeansUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            Seans existSeans = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            _mapper.Map(model, existSeans);
            await _repo.UpdateAsync(existSeans);
        }
    }
}
