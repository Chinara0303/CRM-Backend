using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Account;
using Services.Helpers.Responses;
using Services.Services.İnterfaces;

namespace CRMApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly IEmailService _emailService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;

        public AccountController(IAccountService service,
                                 IEmailService emailService,
                                 UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signinManager)
        {
            _service = service;
            _emailService = emailService;
            _userManager = userManager;
            _signinManager = signinManager;
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SignUp([FromForm] SignUpDto request)
        {
            ArgumentNullException.ThrowIfNull(request, ExceptionResponseMessages.ParametrNotFoundMessage);
            
            SignUpResponse response = await _service.SignUpAsync(request)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            //string token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

            string link = Url.Action(nameof(ConfirmEmail), "Account",
                new { userId = response.User.Id, response.Token },
                Request.Scheme, Request.Host.ToString());

            string subject = "Register Confirmation";
            string html = string.Empty;

            using (StreamReader reader = new("wwwroot/verify.html"))
            {
                html = reader.ReadToEnd();
            }

            html = html.Replace("{{link}}", link);

            _emailService.Send(response.User.Email, subject, html);

            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SignIn([FromForm] SignInDto request)
        {
            ArgumentNullException.ThrowIfNull(request, ExceptionResponseMessages.ParametrNotFoundMessage);

            return Ok(await _service.SignInAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            ArgumentNullException.ThrowIfNull(userId, ExceptionResponseMessages.ParametrNotFoundMessage);
            ArgumentNullException.ThrowIfNull(token, ExceptionResponseMessages.ParametrNotFoundMessage);

            AppUser user = await _userManager.FindByIdAsync(userId)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            await _userManager.ConfirmEmailAsync(user, token);

            //await _signinManager.SignInAsync(user, user.IsRememberMe, null);

            SignInDto signInDto = new()
            {
                UserName = user.UserName,
                Email = user.Email,
                IsRememberMe = user.IsRememberMe,
                Password = user.PasswordHash,
                ConfirmPassword = user.PasswordHash
            };
            await _service.SignInAsync(signInDto);

            return Ok();
        }
    }
}
