﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.About;
using Services.Services.İnterfaces;
using Services.Validations.About;

namespace CRMApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _service;
        public AboutController(IAboutService service)
        {
            _service = service; 
        }
        
        [HttpPost]
        [Authorize]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] AboutCreateDto request)
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
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(AboutUpdateDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute]int? id, [FromForm] AboutUpdateDto request)
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
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            try
            {
                await _service.DeleteAsync(id);
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


        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(AboutDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetById([FromRoute] int? id)
        {
            try
            {
                return Ok(await _service.GetByIdAsync(id));
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
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<AboutDto>))]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
