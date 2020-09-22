using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FooOffer.BusinessLogic.Dto.City
{
    [DataContract]
    public class CityDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
       
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }
}