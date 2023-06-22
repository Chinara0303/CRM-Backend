using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Teacher;
using Services.DTOs.TeacherGroup;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class TeacherGroupService : ITeacherGroupService
    {
        private readonly ITeacherGroupRepository _repo;
        private readonly ITeacherRepository _teacherRepo;
        private readonly IGroupRepository _groupRepo;
        public TeacherGroupService(ITeacherGroupRepository repo,
                                    ITeacherRepository teacherRepo,
                                    IGroupRepository groupRepo)
        {
            _repo = repo;
            _teacherRepo = teacherRepo;
            _groupRepo = groupRepo;
        }
        public async Task CreateAsync(TeacherGroupCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            Group group = await _groupRepo.GetByIdAsync(model.GroupId)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            foreach (var teacherId in model.TeacherIds)
            {
                Teacher teacher = await _teacherRepo.GetByIdAsync(teacherId)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                TeacherGroup teacherGroup = new()
                {
                    Teacher = teacher,
                    Group = group,
                };

                await _repo.CreateAsync(teacherGroup);
            }
        }
    }
}
