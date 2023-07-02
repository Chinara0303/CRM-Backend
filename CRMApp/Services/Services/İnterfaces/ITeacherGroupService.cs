using Services.DTOs.TeacherGroup;

namespace Services.Services.İnterfaces
{
    public interface ITeacherGroupService
    {
        Task CreateAsync(TeacherGroupCreateDto model);
        Task UpdateAsync(int id,TeacherGroupUpdateDto model);
    }
}
