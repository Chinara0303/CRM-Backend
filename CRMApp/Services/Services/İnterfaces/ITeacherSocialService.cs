using Services.DTOs.Teacher;
using Services.DTOs.TecherSocial;

namespace Services.Services.İnterfaces
{
    public interface ITeacherSocialService
    {
        Task<IEnumerable<TeacherSocialDto>> GetAllAsync();
        Task<TeacherSocialDto> GetByIdAsync(int? id);
        Task CreateAsync(TeacherSocialCreateDto model);
        Task UpdateAsync(int? id, TeacherSocialUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
