using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FooOffer.BusinessLogic.Dto.Alternative;
using FooOffer.BusinessLogic.Dto.City;
using FooOffer.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FooOffer.Api.Controllers.V1
{
    [Route("api/v1/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesService _citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CityDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType( typeof(Exception), 500)]
        public async Task<IActionResult> AllCities()
        {
            try
            {
                var response = await _citiesService.GetCitiesAsync();
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        
        [HttpGet("{cityId}")]
        [ProducesResponseType(typeof(IEnumerable<AlternativeDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType( typeof(Exception), 500)]
        public async Task<IActionResult> AvailableAlternatives([FromRoute] int cityId)
        {
            if (cityId < 1)
                return BadRequest($"Invalid cityId: {cityId}");
            
            try
            {
                var response = await _citiesService.GetAvailableAlternativesAsync(cityId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}