using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.About;
using Services.DTOs.Course;
using Services.Helpers.Extentions;
using Services.Services.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repo;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository repo,
                             IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CourseCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            var mappedData = _mapper.Map<Course>(model);

            mappedData.Image = await model.Photo.GetBytes();

            await _repo.CreateAsync(mappedData);
        }

        public async Task<IEnumerable<CourseListDto>> GetAllAsync()
        {
            IEnumerable<Course> existCourses = await _repo.GetAllWithIncludes(c=>c.Groups);

            IEnumerable<CourseListDto> mappedDatas = _mapper.Map<IEnumerable<CourseListDto>>(existCourses);

            foreach (var data in mappedDatas)
            {
                Course course = existCourses.FirstOrDefault(m => m.Id == data.Id);

                if (course is not null)
                {
                    List<string> images = new();
                    images.Add(Convert.ToBase64String(course.Image));
                    data.Images = images;
                }
            }
            return mappedDatas;
        }

        public async Task<CourseDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Course existCourse = await _repo.GetByIdAsync(id);
            var mappedData = _mapper.Map<CourseDto>(existCourse);

            mappedData.Image = Convert.ToBase64String(existCourse.Image);
            return mappedData;
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Course existCourse = await _repo.GetByIdAsync(id);
            await _repo.SoftDeleteAsync(existCourse);
        }

        public async Task UpdateAsync(int? id, CourseUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            Course existCourse = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            Course mappedData = _mapper.Map(model, existCourse);
            if (model.Photo is not null)
                mappedData.Image = await model.Photo.GetBytes();

            await _repo.UpdateAsync(mappedData);
        }
    }
}
