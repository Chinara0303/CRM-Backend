using Services.DTOs.Course;

namespace Services.Services.İnterfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseListDto>> GetAllAsync();
        Task<CourseDto> GetByIdAsync(int? id);
        Task CreateAsync(CourseCreateDto model);
        Task UpdateAsync(int? id, CourseUpdateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
