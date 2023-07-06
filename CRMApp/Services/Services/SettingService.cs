using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.About;
using Services.DTOs.Banner;
using Services.DTOs.Setting;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _repo;
        private readonly IMapper _mapper;
        public SettingService(ISettingRepository repo,
                              IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;   
        }

        public async Task<IEnumerable<SettingDto>> GetAllAsync()
        {
            IEnumerable<Setting> existSettings = await _repo.GetAllAsync();

            IEnumerable<SettingDto> mappedDatas = _mapper.Map<IEnumerable<SettingDto>>(existSettings);

            foreach (var data in mappedDatas)
            {
                Setting setting = existSettings.FirstOrDefault(m => m.Id == data.Id)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            }
            return mappedDatas;
        }

        public async Task<SettingDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);

            Setting existSetting = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            var mappedData = _mapper.Map<SettingDto>(existSetting);

            return mappedData;
        }

        public async Task UpdateAsync(int? id, SettingUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            Setting existSetting = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            Setting mappedData = _mapper.Map(model, existSetting);

            //if (model.Photo is not null)
            //    mappedData.Image = await model.Photo.GetBytes();

            await _repo.UpdateAsync(mappedData);
        }
        public Task DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
