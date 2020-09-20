using System.Collections.Generic;
using System.Threading.Tasks;
using FooOffer.BusinessLogic.Dto.Alternative;
using FooOffer.Core.Entities;

namespace FooOffer.BusinessLogic.Interfaces
{
    public interface IAlternativeService
    {
        Task<IEnumerable<AlternativeDto>> GetAvailableServicesByCityIdAsync(int cityId);
        Task<AlternativeDto> GetAlternativeByIdAsync(int offerServiceServiceId);
    }
}