using CRMApp.Helpers;
using Domain.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.TeacherGroup;
using Services.Services.İnterfaces;
using Services.Validations.TeacherGroup;

namespace CRMApp.Controllers
{
    public class TeacherGroupController : Controller
    {
        private readonly ITeacherGroupService _service;
        public TeacherGroupController(ITeacherGroupService service)
        {
            _service = service;
        }


        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Create([FromForm] TeacherGroupCreateDto request)
        {
            try
            {
                var validation = new CreateDtoValidator().Validate(request);
                if (!validation.IsValid)
                {
                    var errors = validation.Errors.Select(error => error.ErrorMessage).ToList();
                    return BadRequest(errors);
                }

                await _service.CreateAsync(request);
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
        }

    }
}
