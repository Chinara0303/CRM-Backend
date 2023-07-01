using AutoMapper;
using CRMApp.Helpers;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Student;
using Services.DTOs.Teacher;
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

            Group existGroup = await _groupRepo.GetByIdAsync(mappedData.GroupId) 
                ?? throw new NullReferenceException(ExceptionResponseMessages.NotFoundMessage);

            mappedData.Image = await model.Photo.GetBytes();

            await _repo.CreateAsync(mappedData);
        }

        public async Task<Paginate<StudentListDto>> GetAllAsync(int skip = 1,int take = 2)
        {
            IEnumerable<Student> existStudents = await _repo.GetAllWithIncludes(s => s.Group);

            IEnumerable<StudentListDto> mappedDatas = _mapper.Map<IEnumerable<StudentListDto>>(existStudents);

            foreach (var data in mappedDatas)
            {
                Student student = existStudents.FirstOrDefault(m => m.Id == data.Id)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                List<string> images = new();
                images.Add(Convert.ToBase64String(student.Image));
                data.Image = images;
                data.GroupName = student.Group.Name;
            }
            Paginate<StudentListDto> paginatedData = _repo.PaginatedData(mappedDatas, skip, take);

            return paginatedData;
        }

        public async Task<StudentDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);

            Student existStudent = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            StudentDto mappedData = _mapper.Map<StudentDto>(existStudent);

            mappedData.Image = Convert.ToBase64String(existStudent.Image);
            return mappedData;
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
           
            Student existStudent = await _repo.GetByIdAsync(id) 
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
           
            await _repo.SoftDeleteAsync(existStudent);
        }

        public async Task UpdateAsync(int? id, StudentUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            Student existStudent = await _repo.GetByIdAsync(id) 
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            Student mappedData = _mapper.Map(model, existStudent);

            if (model.Photo is not null)
                mappedData.Image = await model.Photo.GetBytes();

            await _repo.UpdateAsync(mappedData);
        }

        public async Task<IEnumerable<StudentListDto>> SearchAsync(string searchText)
        {
            IEnumerable<Student> existStudents = await _repo.GetAllWithIncludes(s => s.Group);

            IEnumerable<StudentListDto> mappedDatas = new List<StudentListDto>();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                mappedDatas = _mapper.Map<IEnumerable<StudentListDto>>(existStudents);

                foreach (var data in mappedDatas)
                {
                    Student student = existStudents.FirstOrDefault(m => m.Id == data.Id)
                        ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                    List<string> images = new();
                    images.Add(Convert.ToBase64String(student.Image));
                    data.Image = images;
                    data.GroupName = student.Group.Name;
                }
                return mappedDatas;
            }

            var filteredDatas = await _repo.GetAllAsync(e => e.FullName.ToLower().Trim().Contains(searchText.ToLower().Trim())
                                                       || e.Email.ToLower().Trim().Contains(searchText.ToLower().Trim()));

            mappedDatas = _mapper.Map<IEnumerable<StudentListDto>>(filteredDatas);

            foreach (var data in mappedDatas)
            {
                Student student = existStudents.FirstOrDefault(m => m.Id == data.Id)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                List<string> images = new();
                images.Add(Convert.ToBase64String(student.Image));
                data.Image = images;
                data.GroupName = student.Group.Name;
            }
            return mappedDatas;
        }

        public async Task<IEnumerable<StudentListDto>> FilterAsync(string filterValue)
        {
            IEnumerable<Student> existStudents = await _repo.GetAllWithIncludes(s => s.Group);

            switch (filterValue)
            {
                case "ascending":
                    existStudents = existStudents.OrderBy(e => e.Age);
                    break;
                case "descending":
                    existStudents = existStudents.OrderByDescending(e => e.Age);
                    break;
                default:
                    break;
            }

            IEnumerable<StudentListDto> mappedDatas = _mapper.Map<IEnumerable<StudentListDto>>(existStudents);
          
            foreach (var data in mappedDatas)
            {
                Student student = existStudents.FirstOrDefault(m => m.Id == data.Id)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                List<string> images = new();
                images.Add(Convert.ToBase64String(student.Image));
                data.Image = images;
                data.GroupName = student.Group.Name;
            }

            return mappedDatas;
        }
    }
}
