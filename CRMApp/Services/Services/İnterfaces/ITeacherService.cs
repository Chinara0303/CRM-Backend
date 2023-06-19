using Services.DTOs.Teacher;

namespace Services.Services.İnterfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherListDto>> GetAllAsync();
        Task<TeacherDto> GetByIdAsync(int? id);
        Task CreateAsync(TeacherCreateDto model);
        Task UpdateAsync(int? id, TeacherUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
