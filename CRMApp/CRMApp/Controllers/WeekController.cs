
using CRMApp.Helpers;
using Domain.Common.Exceptions;
using Domain.Entities;
using Domain.Helpers.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories.İnterfaces;

namespace CRMApp.Controllers
{
    public class WeekController : Controller
    {
        private readonly IWeekRepository _weekRepo;
        public WeekController(IWeekRepository weekRepo)
        {
            _weekRepo = weekRepo;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Weekday weekday)
        {
            try
            {
                var name = Enum.GetName(typeof(Weekday), weekday);

                var newItem = new Week
                {
                    Name = name,
                    Weekday = weekday
                };

                await _weekRepo.CreateAsync(newItem);
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
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _weekRepo.GetAllAsync());
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
