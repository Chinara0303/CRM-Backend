using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.About;
using Services.DTOs.Position;
using Services.Helpers.Extentions;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _repo;
        private readonly IMapper _mapper;

        public AboutService(IAboutRepository repo,
                            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(AboutCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            var mappedData = _mapper.Map<About>(model);

            mappedData.Image = await model.Photo.GetBytes();

            await _repo.CreateAsync(mappedData);
        }

        public async Task<IEnumerable<AboutListDto>> GetAllAsync()
        {
            IEnumerable<About> existAbouts = await _repo.GetAllAsync();
            
            IEnumerable<AboutListDto> mappedDatas = _mapper.Map<IEnumerable<AboutListDto>>(existAbouts);

            foreach (var data in mappedDatas)
            {
                About about = existAbouts.FirstOrDefault(m => m.Id == data.Id);

                if(about is not null)
                {
                    List<string> images = new();
                    images.Add(Convert.ToBase64String(about.Image));
                    data.Images = images;
                }
            }
            return mappedDatas;
        }

        public async Task<AboutDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            About existAbout = await _repo.GetByIdAsync(id);
            var mappedData = _mapper.Map<AboutDto>(existAbout);

            mappedData.Image = Convert.ToBase64String(existAbout.Image);
            return mappedData;
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            About existAbout = await _repo.GetByIdAsync(id);
            await _repo.SoftDeleteAsync(existAbout);
        }

        public async Task UpdateAsync(int? id, AboutUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            About existAbout = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            About mappedData = _mapper.Map(model, existAbout);
            if (model.Photo is not null)
                mappedData.Image = await model.Photo.GetBytes();

            await _repo.UpdateAsync(mappedData);
        }
    }
}
