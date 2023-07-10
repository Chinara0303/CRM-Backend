using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.TecherSocial;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class TeacherSocialService : ITeacherSocialService
    {
        private readonly ITeacherSocialRepository _repo;
        private readonly ITeacherRepository _teacherRepo;
        private readonly IMapper _mapper;
        public TeacherSocialService(ITeacherSocialRepository repo,
                            IMapper mapper,
                            ITeacherRepository teacherRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _teacherRepo = teacherRepo;

        }
        public async Task CreateAsync(TeacherSocialCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            _ = await _teacherRepo.GetByIdAsync(model.TeacherId)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            await _repo.CreateAsync(_mapper.Map<TeacherSocial>(model));
        }

        public async Task<IEnumerable<TeacherSocialDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<TeacherSocialDto>>(await _repo.GetAllWithIncludes(t => t.Teacher));
        }

        public async Task<TeacherSocialDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            return _mapper.Map<TeacherSocialDto>(await _repo.GetByIdAsync(id));
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);

            TeacherSocial existSocial = await _repo.GetByIdAsync(id) 
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            await _repo.SoftDeleteAsync(existSocial);
        }

        public async Task UpdateAsync(int? id, TeacherSocialUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            TeacherSocial existSocial = await _repo.GetByIdAsync(id) 
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            Teacher teacher = await _teacherRepo.GetByIdAsync(model.TeacherId)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            _mapper.Map(model, existSocial);
            await _repo.UpdateAsync(existSocial);
        }
    }
}
