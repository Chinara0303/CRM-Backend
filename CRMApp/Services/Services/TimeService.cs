﻿using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Time;
using Services.Services.İnterfaces;
namespace Services.Services
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _repo;
        private readonly IMapper _mapper;
        public TimeService(ITimeRepository repo,
                           IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(TimeCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);
            var mappedData = _mapper.Map<Time>(model);

            mappedData.Interval = String.Join('-', model.Start, model.End);

            await _repo.CreateAsync(mappedData);
        }

        public async Task<IEnumerable<TimeListDto>> GetAllAsync()
        {
            var existTimes = await _repo.GetAllWithIncludes(t => t.Seans);

            var mappedDatas = _mapper.Map<IEnumerable<TimeListDto>>(existTimes);
          
            foreach (var data in mappedDatas)
            {
                Time time = existTimes.Where(g => g.Id == data.Id).FirstOrDefault();

                IEnumerable<Seans> seanses = await _repo.GetFullDataForSeansAsync(time.SeansId);

                foreach (var seans in seanses)
                {
                    data.SeansName = seans.Name;
                }
            }
            return mappedDatas;
        }

        public async Task<TimeDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Time existTime = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            var mappedData = _mapper.Map<TimeDto>(existTime);

            mappedData.Start = existTime.Interval.Split('-')[0];
            mappedData.End = existTime.Interval.Split('-')[1];

            return mappedData;
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Time existTime = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            await _repo.SoftDeleteAsync(existTime);
        }

        public async Task UpdateAsync(int? id, TimeUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            Time existTime = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            var mappedData = _mapper.Map(model, existTime);

            mappedData.Interval = String.Join('-', model.Start, model.End);

            await _repo.UpdateAsync(existTime);
        }
    }
}
