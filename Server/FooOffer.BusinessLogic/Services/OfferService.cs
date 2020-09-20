using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FooOffer.BusinessLogic.Common.Attributes;
using FooOffer.BusinessLogic.Dto.Offer;
using FooOffer.BusinessLogic.Interfaces;
using FooOffer.BusinessLogic.Repository.Repositories;

namespace FooOffer.BusinessLogic.Services
{
    [AutoRegisterService]
    public class OfferService : BaseService, IOfferService
    {
        private readonly OfferRepository _offerRepository;
        private readonly ICitiesService _citiesService;
        private readonly IAlternativeService _alternativeService;
        private readonly IMapper _mapper;

        public OfferService(OfferRepository offerRepository, ICitiesService citiesService, 
            IAlternativeService alternativeService, IMapper mapper) : base(mapper)
        {
            _offerRepository = offerRepository;
            _citiesService = citiesService;
            _alternativeService = alternativeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Method used for calculating the offer that will be served to the client
        /// </summary>
        /// <param name="offer">The body payload containing the chosen CityId and the chosen services</param>
        /// <returns>The presentation model containing the calculated offer details</returns>
        public async Task<OfferDto> CalculateOfferAsync(NewOfferDto offer)
        {
            if(offer == null)
                throw new ArgumentNullException("Offer model is null.");
            
            if(!offer.Services.Any())
                throw new Exception("Services not set.");
            
            try
            {
                var response = new OfferDto()
                {
                    City = (await _citiesService.GetCityByIdAsync(offer.CityId))?.Name,
                    OfferItems = await SetOfferItemsAsync(offer.Services)
                };
                
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<IEnumerable<OfferItemDto>> SetOfferItemsAsync(IEnumerable<OfferAlternativeDto> offerServices)
        {
            try
            {
                var offerItems = new List<OfferItemDto>();

                foreach (var offerService in offerServices)
                {
                    offerItems.Add(new OfferItemDto
                    {
                        Alternative = await _alternativeService.GetAlternativeByIdAsync(offerService.ServiceId),
                        Amount = offerService.Amount
                    });
                }

                return offerItems;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}