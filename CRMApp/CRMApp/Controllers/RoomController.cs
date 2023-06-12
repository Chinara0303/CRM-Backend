using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Room;
using Services.Services.İnterfaces;
using Services.Validations.Room;
using System.ComponentModel.DataAnnotations;

namespace CRMApp.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _service;
        public RoomController(IRoomService service)
        {
            _service = service;
        }
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        //[validator(typeof(RoomCreateDtoValidator))]
        public async Task<IActionResult> Create([FromBody] RoomCreateDto request)
        {
            try
            {
                var validator = new RoomCreateDtoValidator();
                var validationResult = validator.Validate(request);

                if (!(new RoomCreateDtoValidator().Validate(request)).IsValid)
                {
                    var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                    return BadRequest(errors);
                }

                await _service.CreateAsync(request);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
