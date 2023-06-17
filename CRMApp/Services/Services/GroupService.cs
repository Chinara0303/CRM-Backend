using AutoMapper;
using Domain.Common.Constants;
using Domain.Entities;
using Domain.Helpers.Enums;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Group;
using Services.Services.İnterfaces;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using System.Xml.Linq;
using Services.DTOs.About;
using Domain.Common.Exceptions;

namespace Services.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _repo;
        private readonly IEducationRepository _eduRepo;
        private readonly IMapper _mapper;

        static int MorningCount = 100;
        static int AfterNoonCount = 300;
        static int EveningCount = 500;
        public GroupService(IGroupRepository repo,
                            IMapper mapper,
                            IEducationRepository eduRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _eduRepo = eduRepo;
        }

        public async Task CreateAsync(GroupCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model.RoomId,ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model.EducationId,ExceptionResponseMessages.ParametrNotFoundMessage);
            
            Group newGroup = new();
            var groups = await _repo.GetAllAsync();
           
            Education selectedEducation = await _eduRepo.GetByIdAsync(model.EducationId) 
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
        
            foreach (var group in groups)
            {
                if (model.RoomId == group.RoomId && model.Weekday == group.Weekday && model.Seans == group.Seans )
                {
                    throw new InvalidException(ExceptionResponseMessages.ExistMessage);
                }
            }

            switch (model.Seans)
            {
                case Seans.Morning:
                    MorningCount++;
                    newGroup.Name += selectedEducation.Name.ToUpper()[..1] + MorningCount;
                    break;
                case Seans.Afternoon:
                    AfterNoonCount++;
                    newGroup.Name += selectedEducation.Name.ToUpper()[..1] + AfterNoonCount;
                    break;
                case Seans.Evening:
                    EveningCount++;
                    newGroup.Name += selectedEducation.Name.ToUpper()[..1] + EveningCount;
                    break;
            }

            newGroup.EducationId = model.EducationId;
            newGroup.RoomId = model.RoomId;
            newGroup.Weekday = model.Weekday;
            newGroup.Seans = model.Seans;

            await _repo.CreateAsync(newGroup);
        }

        public async Task<IEnumerable<GroupListDto>> GetAllAsync()
        {
            IEnumerable<Group> existGroups = await _repo.GetAllWithIncludes(g => g.Education, g => g.Students, g => g.Room);

            IEnumerable<GroupListDto> mappedDatas = _mapper.Map<IEnumerable<GroupListDto>>(existGroups);

            return mappedDatas;
        }

        public async Task<GroupDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            var groups = await _repo.GetAllWithIncludes(g => g.Students, g => g.Education, g => g.Room);
            var group = groups.FirstOrDefault(g => g.Id == id);

            return group == null
                ? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage)
                : _mapper.Map<GroupDto>( _repo.GetEntityAsync(group));
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Group existGroup = await _repo.GetByIdAsync(id) 
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            await _repo.SoftDeleteAsync(existGroup);
        }

        public async Task UpdateAsync(int? id, GroupUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            Group existGroup = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            _mapper.Map(model, existGroup);
            await _repo.UpdateAsync(existGroup);
        }
    }
}
