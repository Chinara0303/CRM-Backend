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
        Task<Paginate<TeacherListDto>> SearchAsync(string searchText,int skip,int take);
        Task<Paginate<TeacherListDto>> FilterAsync(string filterValue,int skip,int take);

    }
}
