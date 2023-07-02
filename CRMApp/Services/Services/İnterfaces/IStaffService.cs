using CRMApp.Helpers;
using Services.DTOs.Staff;

namespace Services.Services.İnterfaces
{
    public interface IStaffService
    {
        Task<Paginate<StaffListDto>> GetAllAsync(int skip, int take);
        Task<StaffDto> GetByIdAsync(int? id);
        Task CreateAsync(StaffCreateDto model);
        Task UpdateAsync(int? id, StaffUpdateDto model);
        Task SoftDeleteAsync(int? id);
        Task<Paginate<StaffListDto>> SearchAsync(string searchText,int skip,int take);
        Task<Paginate<StaffListDto>> FilterAsync(string filterValue, int skip, int take);


    }
}
