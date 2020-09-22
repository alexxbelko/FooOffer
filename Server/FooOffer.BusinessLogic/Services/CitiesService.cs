using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FooOffer.BusinessLogic.Interfaces;
using FooOffer.BusinessLogic.Common.Attributes;
using FooOffer.BusinessLogic.Dto.Alternative;
using FooOffer.BusinessLogic.Dto.City;
using FooOffer.BusinessLogic.Repository.Repositories;

namespace FooOffer.BusinessLogic.Services
{
    [AutoRegisterService]
    public class CitiesService : BaseService, ICitiesService
    {
        private readonly CityRepository _cityRepository;
        private readonly IAlternativeService _alternativeService;
        private readonly IMapper _mapper;

        public CitiesService(CityRepository cityRepository, IAlternativeService alternativeService,
            IMapper mapper) : base(mapper)
        {
            _cityRepository = cityRepository;
            _alternativeService = alternativeService;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<CityDto>> GetCitiesAsync()
        {
            try
            {
                var cities = (await _cityRepository.GetAll())
                    .OrderBy(x => x.Name);
                
                return _mapper.Map<IEnumerable<CityDto>>(cities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CityDto> GetCityByIdAsync(int cityId)
        {
            try
            {
                var city = await _cityRepository.Get(cityId);
                return _mapper.Map<CityDto>(city);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the available availableAlternatives for a cityId
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns>A collection of alternative details that are bookable</returns>
        public async Task<IEnumerable<AlternativeDto>> GetAvailableAlternativesAsync(int cityId)
        {
            try
            {
                var availableServices = 
                    await _alternativeService.GetAvailableServicesByCityIdAsync(cityId);

                return _mapper.Map<IEnumerable<AlternativeDto>>(availableServices);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}