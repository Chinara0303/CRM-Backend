using AutoMapper;
using Domain.Common.Constants;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Group;
using Services.Services.İnterfaces;
using Domain.Common.Exceptions;

namespace Services.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _repo;
        private readonly IEducationRepository _eduRepo;
        private readonly ITimeRepository _timeRepo;
        private readonly IMapper _mapper;

        static int MorningCount = 100;
        static int AfternoonCount = 300;
        static int EveningCount = 500;

        public GroupService(IGroupRepository repo,
                            IMapper mapper,
                            IEducationRepository eduRepo,
                            ITimeRepository timeRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _eduRepo = eduRepo;
            _timeRepo = timeRepo;
        }

        public async Task CreateAsync(GroupCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(model.RoomId, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model.EducationId, ExceptionResponseMessages.ParametrNotFoundMessage);

            Group newGroup = new();

            IEnumerable<Group> groups = await _repo.GetAllAsync();

            Education selectedEducation = await _eduRepo.GetByIdAsync(model.EducationId)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            foreach (var group in groups)
            {
                if (model.RoomId == group.RoomId && model.Weekday == group.Weekday && model.TimeId == group.TimeId)
                {
                    throw new InvalidException(ExceptionResponseMessages.ExistMessage);
                }
            }
           
            Time time = await _timeRepo.GetByIdAsync(model.TimeId);
            string groupName = newGroup.Name += selectedEducation.Name.ToUpper()[..1];

            switch (time.SeansId)
            {
                case 1:
                    MorningCount++;
                    _ = groupName + MorningCount;
                    break;
                case 2:
                    AfternoonCount++;
                    _ = groupName + AfternoonCount;
                    break;
                case 3:
                    EveningCount++;
                    _ = groupName + EveningCount;
                    break;
            }
           
            newGroup.EducationId = model.EducationId;
            newGroup.RoomId = model.RoomId;
            newGroup.Weekday = model.Weekday;
            newGroup.TimeId = time.Id;

            await _repo.CreateAsync(newGroup);
        }

        public async Task<IEnumerable<GroupListDto>> GetAllAsync()
        {
            IEnumerable<Group> existGroups = await _repo
                .GetAllWithIncludes(g => g.Education, g => g.Students, g => g.Room, g => g.TeacherGroups);

            IEnumerable<GroupListDto> mappedDatas = _mapper.Map<IEnumerable<GroupListDto>>(existGroups);

            foreach (var data in mappedDatas)
            {
                Group group = existGroups.Where(g => g.Id == data.Id).FirstOrDefault();

                foreach (var teacherGroup in group.TeacherGroups)
                {
                    data.TeacherIds.Add(teacherGroup.TeacherId);
                }

                data.StudentsCount = group.Students.Count;
            }
            return mappedDatas;
        }

        public async Task<GroupDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            IEnumerable<Group> groups = await _repo.GetAllWithIncludes(g => g.Students, g => g.Education, g => g.Room, g => g.TeacherGroups);

            Group group = groups.FirstOrDefault(g => g.Id == id)
               ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            var mappedData = _mapper.Map<GroupDto>(group);

            foreach (var teacherGroup in group.TeacherGroups)
            {
                mappedData.TeacherIds.Add(teacherGroup.TeacherId);
            }

            mappedData.StudentsCount = group.Students.Count;
            return mappedData;
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

            Group existGroup = await _repo.GetByIdAsync(id) 
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            _mapper.Map(model, existGroup);
          
            await _repo.UpdateAsync(existGroup);
        }
    }
}
