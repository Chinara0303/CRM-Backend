using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Org.BouncyCastle.Crypto;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Education;
using Services.Helpers.Extentions;
using Services.Services.İnterfaces;
using System.Text;

namespace Services.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _repo;
        private readonly IGroupRepository _groupRepo;
        private readonly IMapper _mapper;
        public EducationService(IEducationRepository repo,
                             IMapper mapper,
                             IGroupRepository groupRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _groupRepo = groupRepo;
        }
        public async Task CreateAsync(EducationCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            var mappedData = _mapper.Map<Education>(model);

            mappedData.Image = await model.Photo.GetBytes();

            await _repo.CreateAsync(mappedData);
        }

        public async Task<IEnumerable<EducationListDto>> GetAllAsync()
        {
            IEnumerable<Education> existEducations = await _repo.GetAllWithIncludes(c => c.Groups);
            
            IEnumerable<EducationListDto> mappedDatas = _mapper.Map<IEnumerable<EducationListDto>>(existEducations);
         
            foreach (var data in mappedDatas)
            {
                Education education = existEducations.FirstOrDefault(m => m.Id == data.Id);

                if (education is not null)
                {
                    List<string> images = new();
                    images.Add(Convert.ToBase64String(education.Image));
                    data.Images = images;
                    foreach (var item in education.Groups)
                    {
                       data.GroupIds.Add(item.Id);
                    }
                    data.GroupCount = education.Groups.Count;
                }
            }
            return mappedDatas;
        }

        public async Task<EducationDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Education existEducation = await _repo.GetByIdAsync(id);
            IEnumerable<Group> existGroups = await _groupRepo.GetAllAsync();
            IEnumerable<Group> groupsByEducationId = existGroups.Where(m => m.EducationId == existEducation.Id).ToList();

            EducationDto mappedData = _mapper.Map<EducationDto>(existEducation);
          
            foreach (var item in groupsByEducationId)
            {
                mappedData.GroupIds.Add(item.Id);
            }

            mappedData.GroupCount = groupsByEducationId.Count();
            mappedData.Image = Convert.ToBase64String(existEducation.Image);
            return mappedData;
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Education existEducation = await _repo.GetByIdAsync(id);
            await _repo.SoftDeleteAsync(existEducation);
        }

        public async Task UpdateAsync(int? id, EductaionUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            Education existEducation = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            Education mappedData = _mapper.Map(model, existEducation);
            if (model.Photo is not null)
                mappedData.Image = await model.Photo.GetBytes();

            await _repo.UpdateAsync(mappedData);
        }
    }
}
