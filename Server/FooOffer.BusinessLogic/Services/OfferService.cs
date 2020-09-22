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
                throw new ArgumentNullException("IOffer model is null.");
            
            if(!offer.Alternatives.Any())
                throw new Exception("Services not set.");
            
            try
            {
                var city = await _citiesService.GetCityByIdAsync(offer.CityId);
                
                var response = new OfferDto()
                {
                    City = city.Name,
                    OfferItems = await SetOfferItemsAsync(offer.Alternatives, offer.MainServiceAmount),
                    Currency = city.Currency
                };
                
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<IEnumerable<OfferItemDto>> SetOfferItemsAsync(IEnumerable<int> offerAlternativeIds, 
            decimal mainServiceAmount)
        {
            try
            {
                var offerItems = new List<OfferItemDto>();

                foreach (var alternativeId in offerAlternativeIds)
                {
                    var alternative = await _alternativeService.GetAlternativeByIdAsync(alternativeId);
                    offerItems.Add(new OfferItemDto
                    {
                        Alternative = alternative,
                        Amount = alternative.IsMainAlternative ? mainServiceAmount : 1
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