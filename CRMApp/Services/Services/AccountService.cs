using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.Ocsp;
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

        public Task ConfirmEmail(string userId, string token)
        {
            throw new NotImplementedException();
        }



        public async Task<SignUpResponse> SignUpAsync(SignUpDto model)
        {
            if (model is null) throw new ArgumentNullException("Data not found");
            AppUser user = _mapper.Map<AppUser>(model);
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return new SignUpResponse
                {
                    StatusMessage = "User could not be created",
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }
            return new SignUpResponse { Errors = null, StatusMessage = "User created" };
            //string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<SignInResponse> SignInAsync(SignInDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return new SignInResponse { Token = null, StatusMessage = "Failed", Errors = new List<string>() { "Email or password wrong" } };

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
                return new SignInResponse
                {
                    Token = null,
                    StatusMessage = "Failed",
                    Errors = new List<string>() { "Email or password is wrong" }
                };

            string token = GenerateJwtToken(user.UserName);

            return new SignInResponse { Errors = null, StatusMessage = "Success", Token = token };
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
