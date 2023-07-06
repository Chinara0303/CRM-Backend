using Services.DTOs.Group;

namespace Services.Services.İnterfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupListDto>> GetAllAsync();
        Task<GroupDto> GetByIdAsync(int? id);
        Task CreateAsync(GroupCreateDto model);
        Task UpdateAsync(int? id, GroupUpdateDto model);
        Task SoftDeleteAsync(int? id);
        Task<IEnumerable<GroupSearchDto>> SearchAsync(string searchText);
        Task DeleteTeacherAsync(int teacherId);
    }
}
