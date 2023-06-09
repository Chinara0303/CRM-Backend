﻿using Domain.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Group;
using Services.Services.İnterfaces;
using Services.Validations.Group;

namespace CRMApp.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _service;
        public GroupController(IGroupService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] GroupCreateDto request)
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
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<GroupListDto>))]

        public async Task<IActionResult> GetAll(int skip, int take)
        {
            try
            {
                return Ok(await _service.GetAllAsync(skip,take));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(GroupDto))]
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
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(GroupUpdateDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Update([FromRoute] int? id, [FromForm] GroupUpdateDto request)
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


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SoftDelete([FromRoute] int? id)
        {
            try
            {
                await _service.SoftDeleteAsync(id);
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



        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{teacherId}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteTeacher([FromRoute] int? teacherId)
        {
            try
            {
                await _service.DeleteTeacherAsync((int)teacherId);
                return Ok();
            }
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(string searchText,int skip,int take)
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
    }
}
