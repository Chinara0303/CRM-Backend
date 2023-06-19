
using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.About;
using Services.DTOs.Student;
using Services.Helpers.Extentions;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly IGroupRepository _groupRepo;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository repo,
                              IMapper mapper,
                              IGroupRepository groupRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _groupRepo = groupRepo;
        }
        public async Task CreateAsync(StudentCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);
          
            if (!await _repo.CheckByEmail(model.Email))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }

            Student mappedData = _mapper.Map<Student>(model);
            _ = await _groupRepo.GetByIdAsync(mappedData.GroupId) ?? throw new NullReferenceException(ExceptionResponseMessages.NotFoundMessage);
            mappedData.Image = await model.Photo.GetBytes();

            await _repo.CreateAsync(mappedData);
        }

        public async Task<IEnumerable<StudentListDto>> GetAllAsync()
        {
            IEnumerable<Student> existStudents = await _repo.GetAllWithIncludes(s => s.Group);

            IEnumerable<StudentListDto> mappedDatas = _mapper.Map<IEnumerable<StudentListDto>>(existStudents);

            foreach (var data in mappedDatas)
            {
                Student student = existStudents.FirstOrDefault(m => m.Id == data.Id);

                if (student is not null)
                {
                    List<string> images = new();
                    images.Add(Convert.ToBase64String(student.Image));
                    data.Images = images;
                }
            }
            return mappedDatas;
        }

        public async Task<StudentDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Student existStudent = await _repo.GetByIdAsync(id);
            var mappedData = _mapper.Map<StudentDto>(existStudent);

            mappedData.Image = Convert.ToBase64String(existStudent.Image);
            return mappedData;
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Student existStudent = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            await _repo.SoftDeleteAsync(existStudent);
        }

        public async Task UpdateAsync(int? id, StudentUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            if (!await _repo.CheckByEmail(model.Email))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }

            Student existStudent = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            Student mappedData = _mapper.Map(model, existStudent);
            if (model.Photo is not null)
                mappedData.Image = await model.Photo.GetBytes();

            await _repo.UpdateAsync(mappedData);
        }
    }
}
