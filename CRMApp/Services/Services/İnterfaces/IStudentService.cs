using Services.DTOs.Student;

namespace Services.Services.İnterfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentListDto>> GetAllAsync();
        Task<StudentDto> GetByIdAsync(int? id);
        Task CreateAsync(StudentCreateDto model);
        Task UpdateAsync(int? id, StudentUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
