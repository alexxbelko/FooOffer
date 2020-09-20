using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FooOffer.BusinessLogic.Dto.Alternative
{
    [DataContract]
    public class AlternativeDto
    {
        [JsonPropertyName("value")]
        public int Id { get; set; }
        
        [JsonPropertyName("label")]
        public string Name { get; set; }
        
        [JsonPropertyName("unit")]
        public string Unit { get; set; }
        
        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }
        
        [JsonPropertyName("includedByDefault")]
        public bool IncludedByDefault { get; set; }
    }
}