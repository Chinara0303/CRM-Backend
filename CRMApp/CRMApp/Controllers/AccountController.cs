using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Account;
using Services.İnterfaces;

namespace CRMApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SignUp([FromForm]SignUpDto request)
        {
            if (request is null) throw new ArgumentNullException("Data not found");
            return Ok(await _service.SignUpAsync(request));
        }

        [HttpGet("verify")]
        public ContentResult VerifyEmail()
        {
            var html = System.IO.File.ReadAllText(@"./verify.html");
            return base.Content(html, "text/html");
        }

    }
}
