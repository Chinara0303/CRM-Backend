using Microsoft.AspNetCore.Identity;
using Services.DTOs.Account;
using Services.Helpers.Responses;

namespace Services.Services.İnterfaces
{
    public interface IAccountService
    {
        Task<SignUpResponse> SignUpAsync(SignUpDto signUp);
        Task<SignInResponse> SignInAsync(SignInDto signIn);
        Task<IEnumerable<IdentityRole>> GetRolesAsync();
        Task<IEnumerable<UserDto>> GetUsersAsync();
    }
}
