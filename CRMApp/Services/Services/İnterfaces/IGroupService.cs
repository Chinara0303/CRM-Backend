using CRMApp.Helpers;
using Services.DTOs.Group;

namespace Services.Services.İnterfaces
{
    public interface IGroupService
    {
        Task<Paginate<GroupListDto>> GetAllAsync(int skip, int take);
        Task<GroupDto> GetByIdAsync(int? id);
        Task CreateAsync(GroupCreateDto model);
        Task UpdateAsync(int? id, GroupUpdateDto model);
        Task SoftDeleteAsync(int? id);
        Task<Paginate<GroupListDto>> SearchAsync(string searchText, int skip, int take);
        Task DeleteTeacherAsync(int teacherId);
    }
}
