using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FooOffer.BusinessLogic.Dto.Offer
{
    [DataContract]
    public class OfferAlternativeDto
    {
        [JsonPropertyName("id")]
        public int ServiceId { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
    }
}