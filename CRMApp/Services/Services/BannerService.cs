using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.About;
using Services.DTOs.Banner;
using Services.Helpers.Extentions;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class BannerService : IBannerService
    {
        private readonly IBannerRepository _repo;
        private readonly IMapper _mapper;
        public BannerService(IBannerRepository repo,
                             IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(BannerCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            var mappedData = _mapper.Map<Banner>(model);

            mappedData.Image = await model.Photo.GetBytes();

            await _repo.CreateAsync(mappedData);
        }

        public async Task<IEnumerable<BannerListDto>> GetAllAsync()
        {
            IEnumerable<Banner> existBanners = await _repo.GetAllAsync();

            IEnumerable<BannerListDto> mappedDatas = _mapper.Map<IEnumerable<BannerListDto>>(existBanners);

            foreach (var data in mappedDatas)
            {
                Banner banner = existBanners.FirstOrDefault(m => m.Id == data.Id)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                    List<string> images = new();
                    images.Add(Convert.ToBase64String(banner.Image));
                    data.Image = images;
            }
            return mappedDatas;
        }

        public async Task<BannerDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);

            Banner existBanner = await _repo.GetByIdAsync(id)
                 ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            var mappedData = _mapper.Map<BannerDto>(existBanner);

            mappedData.Image = Convert.ToBase64String(existBanner.Image);
            return mappedData;
        }

        public async Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Banner existBanner = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(existBanner);
        }

        public async Task UpdateAsync(int? id, BannerUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            Banner existBanner = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            Banner mappedData = _mapper.Map(model, existBanner);
            if (model.Photo is not null)
                mappedData.Image = await model.Photo.GetBytes();

            await _repo.UpdateAsync(mappedData);
        }
    }
}
