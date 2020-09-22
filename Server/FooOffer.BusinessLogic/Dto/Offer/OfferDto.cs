using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using FooOffer.BusinessLogic.Dto.City;

namespace FooOffer.BusinessLogic.Dto.Offer
{
    [DataContract]
    public class OfferDto
    {
        [JsonPropertyName("offerDateTime")] 
        public DateTime OfferDateTime => DateTime.Now;
        
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        
        [JsonPropertyName("offerItems")]
        public IEnumerable<OfferItemDto> OfferItems { get; set; }

        [JsonPropertyName("grandTotal")] 
        public decimal Total => SetTotal();
        
        private decimal SetTotal()
        {
            if (OfferItems.Any())
            {
                return Math.Round(OfferItems.Select(x => x.ItemSum).Sum(), 2);
            }

            return 0;
        }
    }
}