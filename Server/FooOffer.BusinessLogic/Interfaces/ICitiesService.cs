using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FooOffer.BusinessLogic.Dto.Alternative;
using FooOffer.BusinessLogic.Dto.City;

namespace FooOffer.BusinessLogic.Interfaces
{
    public interface ICitiesService
    {
        Task<IEnumerable<CityDto>> GetCitiesAsync();
     
        Task<CityDto> GetCityByIdAsync(int cityId);
        
        /// <summary>
        /// Gets the available availableAlternatives for a cityId
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns>A collection of alternative details that are bookable</returns>
        Task<IEnumerable<AlternativeDto>> GetAvailableAlternativesAsync(int cityId);
    }
}