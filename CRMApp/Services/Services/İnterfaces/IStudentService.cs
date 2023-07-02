using CRMApp.Helpers;
using Services.DTOs.Student;

namespace Services.Services.İnterfaces
{
    public interface IStudentService
    {
        Task<Paginate<StudentListDto>> GetAllAsync(int skip, int take);
        Task<StudentDto> GetByIdAsync(int? id);
        Task CreateAsync(StudentCreateDto model);
        Task UpdateAsync(int? id, StudentUpdateDto model);
        Task SoftDeleteAsync(int? id);
        Task<Paginate<StudentListDto>> SearchAsync(string searchText,int skip,int take);
        Task<Paginate<StudentListDto>> FilterAsync(string filterValue, int skip, int take);

    }
}
