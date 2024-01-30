using CRMApp.Helpers;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Account;
using Services.Helpers.Responses;
using Services.Services.İnterfaces;
using System.IO;

namespace CRMApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly IEmailService _emailService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IAccountService service,
                                 IEmailService emailService,
                                 UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signinManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _service = service;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SignUp([FromForm] SignUpDto request)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request, ExceptionResponseMessages.ParametrNotFoundMessage);

                SignUpResponse response = await _service.SignUpAsync(request)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                if (response.Errors != null)
                {
                    if (response.Errors.Count > 0)
                    {
                        return BadRequest(response.Errors);
                    }
                }


                string subject = "Register Confirmation";
                string html = string.Empty;
                string password = request.Password;

             
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","templates","verify.html");
                 html = System.IO.File.ReadAllText(filePath);
               
                html = html.Replace("{{password}}", password);

                _emailService.Send(response.UserEmail, subject, html);

                return Ok(response);
            }
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return                                       
                    
                    
                    NotFound(ex.Message);
            }
        }


        [HttpPut]
        [Route("{userId}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SetStatus([FromRoute] string userId)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(userId, ExceptionResponseMessages.ParametrNotFoundMessage);

                StatusDto response = await _service.SetStatus(userId);

                if (response.IsActive)
                {
                    string subject = "Confirmation message";
                    string html = string.Empty;

                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "templates", "confirm.html");
                    html = System.IO.File.ReadAllText(filePath);

                    _emailService.Send(response.Email, subject, html);
                }

                return Ok(response);
            }
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }


        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SignIn([FromForm] SignInDto request)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request, ExceptionResponseMessages.ParametrNotFoundMessage);
                return Ok(await _service.SignInAsync(request));
            }
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task CreateRole()
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
        }


        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRoles(int skip, int take)
        {
            return Ok(await _service.GetRolesAsync(skip, take));
        }


        [Authorize]
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Profile()
        {
            return Ok(await _service.Profile());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRoleById([FromRoute] string id)
        {
            return Ok(await _service.GetRoleById(id));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            return Ok(await _service.GetUserByIdAsync(id));
        }


        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUsers(int skip, int take)
        {
            return Ok(await _service.GetUsersAsync(skip, take));
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(string searchText, int skip, int take)
        {
            try
            {
                return Ok(await _service.SearchAsync(searchText, skip, take));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _service.LogoutAsync();
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Filter(string filterValue, int skip, int take)
        {
            try
            {
                return Ok(await _service.FilterAsync(filterValue, skip, take));
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UserSoftDelete([FromRoute] string id)
        {
            try
            {
                await _service.UserSoftDeleteAsync(id);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{userId}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteRole([FromRoute] string userId, [FromQuery] string roleName)
        {
            try
            {
                await _service.DeleteRoleAsync(userId,roleName);
                return Ok();
            }
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

       
        [HttpPut]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(UserUpdateDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UserUpdate([FromForm] UserUpdateDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("Age", "Age must be between 18 and 65");
                    return BadRequest();
                }

                await _service.UserUpdateAsync(request);
                return Ok();
            }
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut]
        [Route("{userId}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(UserUpdateDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UserRoleUpdate([FromRoute] string userId, [FromForm] UserRoleUpdateDto request)
        {
            try
            {
                await _service.UserUpdateRoleAsync(userId,request);
                return Ok();
            }
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(ChangePasswordDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangePassword([FromForm]ChangePasswordDto request)
        {
            try
            {
                await _service.ChangePasswordAsync(request);
                return Ok();
            }
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }



    }
}
