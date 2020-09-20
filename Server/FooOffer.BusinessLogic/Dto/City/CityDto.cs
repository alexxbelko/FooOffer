using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FooOffer.BusinessLogic.Dto.City
{
    [DataContract]
    public class CityDto
    {
        [JsonPropertyName("value")]
        public int Id { get; set; }
       
        [JsonPropertyName("label")]
        public string Name { get; set; }
    }
}