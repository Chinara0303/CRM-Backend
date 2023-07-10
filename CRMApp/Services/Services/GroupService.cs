using AutoMapper;
using Domain.Common.Constants;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Group;
using Services.Services.İnterfaces;
using Domain.Common.Exceptions;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.DTOs.Teacher;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Services.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _repo;
        private readonly ITeacherRepository _teacherRepo;
        private readonly ITeacherGroupRepository _teacherGroupRepo;
        private readonly IEducationRepository _eduRepo;
        private readonly ITimeRepository _timeRepo;
        private readonly IMapper _mapper;

        static int MorningCount = 100;
        static int AfternoonCount = 300;
        static int EveningCount = 500;

        public GroupService(IGroupRepository repo,
                            IMapper mapper,
                            IEducationRepository eduRepo,
                            ITimeRepository timeRepo,
                            ITeacherGroupRepository teacherGroupRepo,
                            ITeacherRepository teacherRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _eduRepo = eduRepo;
            _timeRepo = timeRepo;
            _teacherGroupRepo = teacherGroupRepo;
            _teacherRepo = teacherRepo;
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
                    groupName = groupName + MorningCount;
                    break;
                case 2:
                    AfternoonCount++;
                    groupName = groupName + AfternoonCount;
                    break;
                case 3:
                    EveningCount++;
                    groupName = groupName + EveningCount;
                    break;
            }

            newGroup.Name = groupName;
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

                IEnumerable<Teacher> teachers = await _teacherGroupRepo.GetFullDataForTeacherAsync(group.Id);
                List<TeacherInfoDto> teachersInfo = new();

                foreach (var teacher in teachers)
                {
                    TeacherInfoDto infoDto = new()
                    {
                        TeacherId = teacher.Id,
                        FullName = teacher.FullName,
                        Image = Convert.ToBase64String(teacher.Image)
                    };

                    teachersInfo.Add(infoDto);
                }

                data.TeachersInfo = teachersInfo;
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
            
            IEnumerable<Teacher> teachers = await _teacherGroupRepo.GetFullDataForTeacherAsync(group.Id);

            GroupDto mappedData = _mapper.Map<GroupDto>(group);
           
            List<TeacherInfoDto> teachersInfo = new();

            foreach (var item in teachers)
            {
                TeacherInfoDto infoDto = new()
                {
                    TeacherId = item.Id,
                    FullName = item.FullName,
                    Image = Convert.ToBase64String(item.Image)
                };

                teachersInfo.Add(infoDto);
            }
            mappedData.TeachersInfo = teachersInfo;

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

           IEnumerable<TeacherGroup> existTeacherGroups = await _teacherGroupRepo.GetAllAsync(m => m.GroupId == id);
            existGroup.TeacherGroups = (List<TeacherGroup>)existTeacherGroups;

            List<TeacherGroup> teacherGroups = new();

            _mapper.Map(model, existGroup);

            if (model.TeacherIds != null)
            {
                foreach (var teacherId in model.TeacherIds)
                {
                    if(existTeacherGroups.Any())
                    {
                        foreach (var item in existTeacherGroups)
                        {
                            if (item.TeacherId == teacherId)
                            {
                                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
                            }
                        }
                    }

                    Teacher teacher = await _teacherRepo.GetByIdAsync(teacherId);

                    teacherGroups.Add(new TeacherGroup
                    {
                        Teacher = teacher,
                        Group = existGroup
                    });

                    existGroup.TeacherGroups.AddRange(teacherGroups);
                }
            }
            await _repo.UpdateAsync(existGroup);
        }

        public async Task DeleteTeacherAsync(int teacherId)
        {
            ArgumentNullException.ThrowIfNull(teacherId, ExceptionResponseMessages.ParametrNotFoundMessage);
            IEnumerable<TeacherGroup> teacherGroups = await _teacherGroupRepo.GetAllAsync();

            TeacherGroup teacherGroup = teacherGroups.FirstOrDefault(t => t.TeacherId == teacherId)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            
            await _teacherGroupRepo.DeleteAsync(teacherGroup);
        }

        public async Task<IEnumerable<GroupSearchDto>> SearchAsync(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return _mapper.Map<IEnumerable<GroupSearchDto>>(await _repo.GetAllAsync());
            }
            return _mapper.Map<IEnumerable<GroupSearchDto>>(await _repo.GetAllAsync(e => e.Name.ToLower().Trim().Contains(searchText.ToLower().Trim())));
        }
    }
}
