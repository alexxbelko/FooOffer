using System.Threading.Tasks;
using FooOffer.BusinessLogic.Dto.Offer;

namespace FooOffer.BusinessLogic.Interfaces
{
    public interface IOfferService
    {
        /// <summary>
        /// Method used for calculating the offer that will be served to the client
        /// </summary>
        /// <param name="offer">The body payload containing the chosen CityId and the chosen services</param>
        /// <returns>The presentation model containing the calculated offer details</returns>
        Task<OfferDto> CalculateOfferAsync(NewOfferDto offer);
    }
}