using AutoMapper;
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

namespace Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly JWTSettings _jwtSetting;

        public AccountService(UserManager<AppUser> userManager,
                              RoleManager<IdentityRole> roleManager,
                              IMapper mapper,
                              IOptions<JWTSettings> jwtSetting)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSetting = jwtSetting.Value;
        }

        public async Task<SignUpResponse> SignUpAsync(SignUpDto model)
        {
            ArgumentNullException.ThrowIfNull(model, ExceptionResponseMessages.ParametrNotFoundMessage);

            AppUser user = _mapper.Map<AppUser>(model)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return new SignUpResponse
                {
                    StatusMessage = ExceptionResponseMessages.UserFailedMessage,
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return new SignUpResponse
            {
                Errors = null,
                StatusMessage = ExceptionResponseMessages.UserSuccesMessage,
                Token = token,
                User = user
            };
        }
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
