using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FooOffer.BusinessLogic.Dto.Alternative
{
    [DataContract]
    public class AlternativeDto
    {
        [JsonPropertyName("key")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("unit")]
        public string Unit { get; set; }
        
        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }
        
        [JsonPropertyName("value")]
        public bool IsMainAlternative { get; set; }
    }
}