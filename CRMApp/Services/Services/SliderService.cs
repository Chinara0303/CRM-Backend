﻿
using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.About;
using Services.DTOs.Slider;
using Services.Helpers.Extentions;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _repo;
        private readonly IMapper _mapper;
        public SliderService(ISliderRepository repo,
                             IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(SliderCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            var mappedData = _mapper.Map<Slider>(model);

            mappedData.Image = await model.Photo.GetBytes();

            await _repo.CreateAsync(mappedData);
        }

        public async Task<IEnumerable<SliderListDto>> GetAllAsync()
        {
            IEnumerable<Slider> existSlider = await _repo.GetAllAsync();

            IEnumerable<SliderListDto> mappedDatas = _mapper.Map<IEnumerable<SliderListDto>>(existSlider);

            foreach (var data in mappedDatas)
            {
                Slider slider = existSlider.FirstOrDefault(m => m.Id == data.Id)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                    List<string> images = new();
                    images.Add(Convert.ToBase64String(slider.Image));
                    data.Image = images;
            }
            return mappedDatas;
        }

        public async Task<SliderDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Slider existSlider = await _repo.GetByIdAsync(id);
            var mappedData = _mapper.Map<SliderDto>(existSlider);

            mappedData.Image = Convert.ToBase64String(existSlider.Image);
            return mappedData;
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Slider existSlider = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(existSlider);
        }

        public async Task UpdateAsync(int? id, SliderUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            Slider existSlider = await _repo.GetByIdAsync(id) 
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            Slider mappedData = _mapper.Map(model, existSlider);

            if (model.Photo is not null)
                mappedData.Image = await model.Photo.GetBytes();
           
            await _repo.UpdateAsync(mappedData);
        }
    }
}
