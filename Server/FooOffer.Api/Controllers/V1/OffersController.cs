using System;
using System.Linq;
using System.Threading.Tasks;
using FooOffer.BusinessLogic.Dto.Offer;
using FooOffer.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FooOffer.Api.Controllers.V1
{
    [Route("api/v1/offer")]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OffersController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OfferDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType( typeof(Exception), 500)]
        public async Task<IActionResult> CalculateOffer([FromBody] NewOfferDto offer)
        {
            if (offer == null || offer.Alternatives == null)
                return BadRequest($"Invalid model.");
            
            try
            {
                var response = await _offerService.CalculateOfferAsync(offer);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}