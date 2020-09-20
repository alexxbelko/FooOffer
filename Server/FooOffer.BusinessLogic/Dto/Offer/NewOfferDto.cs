using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FooOffer.BusinessLogic.Dto.Offer
{
    [DataContract]
    public class NewOfferDto
    {
        [JsonPropertyName("cityId")]
        public int CityId { get; set; }

        [JsonPropertyName("services")]
        public IEnumerable<OfferAlternativeDto> Services { get; set; }
    }
}