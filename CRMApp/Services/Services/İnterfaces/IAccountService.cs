using CRMApp.Helpers;
using Services.DTOs.Account;
using Services.Helpers.Responses;

namespace Services.Services.İnterfaces
{
    public interface IAccountService
    {
        Task<SignUpResponse> SignUpAsync(SignUpDto signUp);
        Task<SignInResponse> SignInAsync(SignInDto signIn);
        Task<Paginate<RoleListDto>> GetRolesAsync(int skip,int take);
        Task<Paginate<UserListDto>> GetUsersAsync(int skip,int take);
        Task<RoleDto> GetRoleById(string id);
        Task<UserDto> GetUserByIdAsync(string id);
        Task<Paginate<UserListDto>> SearchAsync(string searchText, int skip, int take);
        Task<Paginate<UserListDto>> FilterAsync(string filterValue, int skip, int take);
        Task AddRoleToUserAsync(UsersRoleDto model);
        Task UserUpdateAsync(UserUpdateDto model);
        Task UserSoftDeleteAsync(string id);
        Task ChangePasswordAsync(ChangePasswordDto model);
        Task<StatusDto> SetStatus(string userId);
        Task<UserDto> Profile();
        Task LogoutAsync();
    }
}
