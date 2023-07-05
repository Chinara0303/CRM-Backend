﻿using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Services.DTOs.Account;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Services.Helpers.Responses;
using System.Data;
using Microsoft.Extensions.Options;
using Services.Services.İnterfaces;
using Services.Helpers.AccountSetting;
using Domain.Common.Exceptions;
using Domain.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Services.Helpers.Extentions;
using CRMApp.Helpers;
using Repository.Repositories.İnterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IPaginateRepository<AppUser> _paginateRepo;
        private readonly IAccountRepository<AppUser> _accountRepo;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly JWTSettings _jwtSetting;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser> userManager,
                              RoleManager<IdentityRole> roleManager,
                              IMapper mapper,
                              IOptions<JWTSettings> jwtSetting,
                              IPaginateRepository<AppUser> paginateRepo,
                              IAccountRepository<AppUser> accountRepo,
                              IHttpContextAccessor httpContextAccessor,
                              SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSetting = jwtSetting.Value;
            _paginateRepo = paginateRepo;
            _accountRepo = accountRepo;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
        }

        public async Task<SignUpResponse> SignUpAsync(SignUpDto model)
        {
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            AppUser user = _mapper.Map<AppUser>(model)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);


            user.Image = await model.Photo.GetBytes();
            user.UserName = model.FullName.Split(" ").ToString();

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return new SignUpResponse
                {
                    StatusMessage = ExceptionResponseMessages.UserFailedMessage,
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            return new SignUpResponse
            {
                Errors = null,
                StatusMessage = ExceptionResponseMessages.UserSuccesMessage,
                User = user
            };
        }

        [AllowAnonymous]
        public async Task<SignInResponse> SignInAsync(SignInDto model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return new SignInResponse
                {
                    Token = null,
                    StatusMessage = ExceptionResponseMessages.FailedMessage,
                    Errors = new List<string>() { ExceptionResponseMessages.WrongMessage }
                };

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
                return new SignInResponse
                {
                    Token = null,
                    StatusMessage = ExceptionResponseMessages.FailedMessage,
                    Errors = new List<string>() { ExceptionResponseMessages.WrongMessage }
                };

            string token = GenerateJwtToken(user.UserName);

            return new SignInResponse
            {
                Errors = null,
                StatusMessage = ExceptionResponseMessages.SuccesMessage,
                Token = token
            };
        }

        public async Task<StatusDto> SetStatus(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            user.IsActive = true;

            StatusDto mappedData = _mapper.Map<StatusDto>(user);
            mappedData.UserId = userId;

            return mappedData;
        }
        public async Task<RoleDto> GetRoleById(string id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);

            IdentityRole existRole = await _roleManager.FindByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);
            //var usersByRole = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync());

            //IEnumerable<> existStaffPosition = await _staffPositionRepo.GetAllAsync();

            //List<StaffPosition> staffPositionByStaffId = existStaffPosition
            //                        .Where(e => e.StaffId == existStaff.Id)
            //                        .ToList();
            RoleDto mappedData = _mapper.Map<RoleDto>(existRole);

            //List<int> positionIds = new();

            //foreach (var item in staffPositionByStaffId)
            //{
            //    positionIds.Add(item.PositionId);
            //    mappedData.PositionIds = positionIds;
            //}

            //mappedData.Image = Convert.ToBase64String(existStaff.Image);

            return mappedData;
        }

        public async Task AddRoleToUserAsync(UsersRoleDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var usersRole = await _userManager.AddToRoleAsync(user, role.ToString());
        }

        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);

            AppUser existUser = await _userManager.FindByIdAsync(id)
               ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            IList<string> usersRole = await _userManager.GetRolesAsync(existUser);

            UserDto mappedData = _mapper.Map<UserDto>(existUser);

            foreach (var userRole in usersRole)
            {
                mappedData.RoleNames.Add(userRole);
            }

            mappedData.Image = Convert.ToBase64String(existUser.Image);

            return mappedData;
        }

        [Authorize]
        public async Task<UserDto> Profile()
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = await _userManager.FindByNameAsync(userName)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            var mappedData = _mapper.Map<UserDto>(user);

            mappedData.Image = Convert.ToBase64String(user.Image);

            return mappedData;
        }
       
        public async Task<Paginate<RoleListDto>> GetRolesAsync(int skip, int take)
        {
            List<IdentityRole> roles = await _roleManager.Roles.ToListAsync()
                   ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            List<RoleListDto> mappedDatas = _mapper.Map<List<RoleListDto>>(roles);

            foreach (var data in mappedDatas)
            {
                var role = roles.FirstOrDefault(u => u.Id == data.Id);
                IList<AppUser> usersRole = await _userManager.GetUsersInRoleAsync(role.Name);

                data.UsersCount = usersRole.Count;
            }

            Paginate<RoleListDto> paginatedData = _paginateRepo.PaginatedData(mappedDatas, skip, take);

            return paginatedData;
        }

        public async Task<Paginate<UserListDto>> GetUsersAsync(int skip, int take)
        {
            List<AppUser> existUsers = await _userManager.Users.ToListAsync();
            List<UserListDto> mappedDatas = _mapper.Map<List<UserListDto>>(existUsers);

            foreach (var data in mappedDatas)
            {
                AppUser user = existUsers.FirstOrDefault(m => m.Id == data.Id)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                IList<string> usersRole = await _userManager.GetRolesAsync(user)
                       ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                foreach (var userRole in usersRole)
                {
                    data.RoleNames.Add(userRole);
                }

                List<string> images = new();
                images.Add(Convert.ToBase64String(user.Image));

                data.Image = images;
            }

            Paginate<UserListDto> paginatedData = _paginateRepo.PaginatedData(mappedDatas, skip, take);
            return paginatedData;
        }

        public async Task<Paginate<UserListDto>> SearchAsync(string searchText, int skip, int take)
        {
            IEnumerable<AppUser> existUsers = await _userManager.Users.ToListAsync();

            List<UserListDto> mappedDatas = new List<UserListDto>();

            Paginate<UserListDto> paginatedData = new(mappedDatas, skip, take);

            if (string.IsNullOrWhiteSpace(searchText))
            {
                mappedDatas = _mapper.Map<List<UserListDto>>(existUsers);
                foreach (var data in mappedDatas)
                {
                    AppUser user = existUsers.FirstOrDefault(m => m.Id == data.Id)
                        ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                    List<string> images = new();
                    List<int> positionIds = new();

                    images.Add(Convert.ToBase64String(user.Image));
                    data.Image = images;

                }

                paginatedData = _paginateRepo.PaginatedData(mappedDatas, skip, take);

                return paginatedData;
            }


            var filteredDatas = await _accountRepo.GetAllAsync(e => e.FullName.ToLower().Trim().Contains(searchText.ToLower().Trim()));

            mappedDatas = _mapper.Map<List<UserListDto>>(filteredDatas);

            foreach (var data in mappedDatas)
            {
                AppUser user = existUsers.FirstOrDefault(m => m.Id == data.Id)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                List<string> images = new();

                images.Add(Convert.ToBase64String(user.Image));
                data.Image = images;
            }

            paginatedData = _paginateRepo.PaginatedData(mappedDatas, skip, take);

            return paginatedData;
        }

        public async Task<Paginate<UserListDto>> FilterAsync(string filterValue, int skip, int take)
        {
            IEnumerable<AppUser> existUsers = await _userManager.Users.ToListAsync();

            switch (filterValue)
            {
                case "ascending":
                    existUsers = existUsers.OrderBy(e => e.Age);
                    break;
                case "descending":
                    existUsers = existUsers.OrderByDescending(e => e.Age);
                    break;
                default:
                    break;
            }

            List<UserListDto> mappedDatas = _mapper.Map<List<UserListDto>>(existUsers);

            foreach (var data in mappedDatas)
            {
                AppUser user = existUsers.FirstOrDefault(m => m.Id == data.Id)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                List<string> images = new();

                images.Add(Convert.ToBase64String(user.Image));
                data.Image = images;

            }

            Paginate<UserListDto> paginatedData = _paginateRepo.PaginatedData(mappedDatas, skip, take);

            return paginatedData;
        }

        [Authorize]
        public async Task UserUpdateAsync(UserUpdateDto model)
        {
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            string userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            AppUser existUser = await _userManager.FindByNameAsync(userName)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            AppUser mappedData = _mapper.Map(model, existUser);

            if (model.Photo is not null)
                mappedData.Image = await model.Photo.GetBytes();

            await _accountRepo.UpdateAsync(mappedData);
        }

        public async Task UserSoftDeleteAsync(string id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);

            AppUser existUser = await _userManager.FindByIdAsync(id)
                            ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            await _accountRepo.SoftDeleteAsync(existUser);
        }
       
        [Authorize]
        public async Task ChangePasswordAsync(ChangePasswordDto model)
        {
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);
            string userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            AppUser existUser = await _userManager.FindByNameAsync(userName)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            await _userManager.ChangePasswordAsync(existUser, model.OldPassword, model.NewPassword);
        }
    
        [Authorize]
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        private string GenerateJwtToken(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, username)
            };

            //roles.ForEach(role =>
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //});
            var keyy = _jwtSetting.Key;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSetting.ExpireDays));

            var token = new JwtSecurityToken(
                _jwtSetting.Issuer,
                _jwtSetting.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
