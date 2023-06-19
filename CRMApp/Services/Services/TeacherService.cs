﻿using AutoMapper;
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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repo;
        private readonly IMapper _mapper;
        public TeacherService(ITeacherRepository repo, 
                              IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(TeacherCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);
            if (!await _repo.CheckByEmail(model.Email))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }

            Teacher mappedData = _mapper.Map<Teacher>(model);
            mappedData.Image = await model.Photo.GetBytes();
            await _repo.CreateAsync(mappedData);
        }

        public async Task<IEnumerable<TeacherListDto>> GetAllAsync()
        {
            IEnumerable<Teacher> existTeachers = await _repo.GetAllAsync();

            IEnumerable<TeacherListDto> mappedDatas = _mapper.Map<IEnumerable<TeacherListDto>>(existTeachers);

            foreach (var data in mappedDatas)
            {
                Teacher teacher = existTeachers.FirstOrDefault(m => m.Id == data.Id);

                if (teacher is not null)
                {
                    List<string> images = new();
                    images.Add(Convert.ToBase64String(teacher.Image));
                    data.Images = images;
                }
            }
            return mappedDatas;
        }

        public async Task<TeacherDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Teacher existTeacher = await _repo.GetByIdAsync(id);
            var mappedData = _mapper.Map<TeacherDto>(existTeacher);

            mappedData.Image = Convert.ToBase64String(existTeacher.Image);
            return mappedData;
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            Teacher existTeacher = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            await _repo.SoftDeleteAsync(existTeacher);
        }

        public async Task UpdateAsync(int? id, TeacherUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);
            Teacher existTeacher = await _repo.GetByIdAsync(id) ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            if (!await _repo.CheckByEmail(model.Email))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }

            Teacher mappedData = _mapper.Map(model, existTeacher);
            if (model.Photo is not null)
                mappedData.Image = await model.Photo.GetBytes();

            await _repo.UpdateAsync(mappedData);
        }
    }
}