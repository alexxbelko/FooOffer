using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using FooOffer.BusinessLogic.Dto.Alternative;

namespace FooOffer.BusinessLogic.Dto.Offer
{
    [DataContract]
    public class OfferItemDto
    { 
        [JsonPropertyName("alternative")]
        public AlternativeDto Alternative { get; set; }
        
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("sum")] 
        public decimal ItemSum => SetItemSum();

        private decimal SetItemSum()
        {
            if (Alternative != null)
                return Alternative.UnitPrice * Amount;
        
            return 0;
        }
    }
}