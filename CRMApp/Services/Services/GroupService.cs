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
        private readonly ICourseRepository _courseRepo;
        private readonly IMapper _mapper;

        static int MorningCount = 100;
        static int AfterNoonCount = 300;
        static int EveningCount = 500;
        public GroupService(IGroupRepository repo,
                            IMapper mapper,
                            ICourseRepository courseRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _courseRepo = courseRepo;

        }

        public async Task CreateAsync(GroupCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model.RoomId,ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model.CourseId,ExceptionResponseMessages.ParametrNotFoundMessage);
            
            Group newGroup = new();
            var groups = await _repo.GetAllAsync();
            Course selectedCourse = await _courseRepo.GetByIdAsync(model.CourseId);

            foreach (var group in groups)
            {
                if (model.RoomId == group.RoomId && model.Weekday == group.Weekday && model.Seans == group.Seans )
                {
                    throw new InvalidException(ExceptionResponseMessages.ExistMessage);
                }
            }

            if (model.Seans == Seans.Morning)
            {
                MorningCount++;
                newGroup.Name += selectedCourse.Name.ToUpper()[..1] + MorningCount;
            }
            else if (model.Seans == Seans.Afternoon)
            {
                AfterNoonCount++;
                newGroup.Name += selectedCourse.Name.ToUpper()[..1] + AfterNoonCount;
            }
            else if (model.Seans == Seans.Evening)
            {
                EveningCount++;
                newGroup.Name += selectedCourse.Name.ToUpper()[..1] + EveningCount;
            }

            newGroup.CourseId = model.CourseId;
            newGroup.RoomId = model.RoomId;
            newGroup.Weekday = model.Weekday;
            newGroup.Seans = model.Seans;

            await _repo.CreateAsync(newGroup);
        }

        public async Task<IEnumerable<GroupListDto>> GetAllAsync()
        {
            IEnumerable<Group> existGroups = await _repo.GetAllWithIncludes(g => g.Course, g => g.Students, g => g.Room);

            IEnumerable<GroupListDto> mappedDatas = _mapper.Map<IEnumerable<GroupListDto>>(existGroups);

            return mappedDatas;
        }

        public async Task<GroupDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            var groups = await _repo.GetAllWithIncludes(g => g.Students, g => g.Course, g => g.Room);
            var group = groups.FirstOrDefault(g => g.Id == id);
            return _mapper.Map<GroupDto>( _repo.GetEntityAsync(group));
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Group existGroup = await _repo.GetByIdAsync(id);
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
