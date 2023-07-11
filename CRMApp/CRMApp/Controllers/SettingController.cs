using Domain.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Setting;
using Services.Services.İnterfaces;
using Services.Validations.Setting;

namespace CRMApp.Controllers
{
    public class SettingController : Controller
    {
        private readonly ISettingService _service;
        public SettingController(ISettingService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<SettingDto>))]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok( _service.GetAllWithDict());
            }
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<SettingDto>))]

        public async Task<IActionResult> GetSettings()
        {
            try
            {
                return Ok(_service.GetAllAsync());
            }
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(SettingUpdateDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int? id, [FromForm] SettingUpdateDto request)
        {
            try
            {
                var validation = new UpdateDtoValidator().Validate(request);
                if (!validation.IsValid)
                {
                    var errors = validation.Errors.Select(error => error.ErrorMessage).ToList();
                    return BadRequest(errors);
                }
                await _service.UpdateAsync(id, request);
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


        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(SettingDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetById([FromRoute] int? id)
        {
            try
            {
                return Ok(await _service.GetByIdAsync(id));
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
