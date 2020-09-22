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

        [JsonPropertyName("alternatives")]
        public IEnumerable<int> Alternatives { get; set; }

        [JsonPropertyName("mainAlternativeAmount")]
        public decimal MainServiceAmount { get; set; }
    }
}