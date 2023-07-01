using CRMApp.Helpers;
using Services.DTOs.Teacher;

namespace Services.Services.İnterfaces
{
    public interface ITeacherService
    {
        Task<Paginate<TeacherListDto>> GetAllAsync(int pageNumber, int pageSize);
        Task<TeacherDto> GetByIdAsync(int? id);
        Task CreateAsync(TeacherCreateDto model);
        Task UpdateAsync(int? id, TeacherUpdateDto model);
        Task SoftDeleteAsync(int? id);
        Task<IEnumerable<TeacherListDto>> SearchAsync(string searchText);
        Task<IEnumerable<TeacherListDto>> FilterAsync(string filterValue);

    }
}
