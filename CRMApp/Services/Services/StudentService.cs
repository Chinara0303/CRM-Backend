using AutoMapper;
using CRMApp.Helpers;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Student;
using Services.Helpers.Extentions;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly IGroupRepository _groupRepo;
        private readonly IPaginateRepository<Student> _paginateRepo;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository repo,
                              IMapper mapper,
                              IGroupRepository groupRepo,
                              IPaginateRepository<Student> paginateRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _groupRepo = groupRepo;
            _paginateRepo = paginateRepo;
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

        public async Task<Paginate<StudentListDto>> GetAllAsync(int skip = 1,int take = 3)
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
            Paginate<StudentListDto> paginatedData = _paginateRepo.PaginatedData(mappedDatas, skip, take);

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

        public async Task<Paginate<StudentListDto>> SearchAsync(string searchText,int skip,int take)
        {
            IEnumerable<Student> existStudents = await _repo.GetAllWithIncludes(s => s.Group);

            List<StudentListDto> mappedDatas = new();

            Paginate<StudentListDto> paginatedData = new(mappedDatas, skip, take);

            if (string.IsNullOrWhiteSpace(searchText))
            {
                mappedDatas = _mapper.Map<List<StudentListDto>>(existStudents);
               
                foreach (var data in mappedDatas)
                {
                    Student student = existStudents.FirstOrDefault(m => m.Id == data.Id)
                        ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                    List<string> images = new();
                    images.Add(Convert.ToBase64String(student.Image));
                    data.Image = images;
                    data.GroupName = student.Group.Name;
                }

                paginatedData = _paginateRepo.PaginatedData(mappedDatas, skip, take);
               
                return paginatedData;
            }

            var filteredDatas = await _repo.GetAllAsync(e => e.FullName.ToLower()
            .Trim().Contains(searchText.ToLower().Trim()));

            mappedDatas = _mapper.Map<List<StudentListDto>>(filteredDatas);

            foreach (var data in mappedDatas)
            {
                Student student = existStudents.FirstOrDefault(m => m.Id == data.Id)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                List<string> images = new();
                images.Add(Convert.ToBase64String(student.Image));
                data.Image = images;
                data.GroupName = student.Group.Name;
            }

            paginatedData = _paginateRepo.PaginatedData(mappedDatas, skip, take);

            return paginatedData;
        }

        public async Task<Paginate<StudentListDto>> FilterAsync(string filterValue, int skip, int take)
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

            List<StudentListDto> mappedDatas = _mapper.Map<List<StudentListDto>>(existStudents);
          
            foreach (var data in mappedDatas)
            {
                Student student = existStudents.FirstOrDefault(m => m.Id == data.Id)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                List<string> images = new();
                images.Add(Convert.ToBase64String(student.Image));
                data.Image = images;
                data.GroupName = student.Group.Name;
            }

            Paginate<StudentListDto> paginatedData = _paginateRepo.PaginatedData(mappedDatas, skip, take);

            return paginatedData;
        }
    }
}
