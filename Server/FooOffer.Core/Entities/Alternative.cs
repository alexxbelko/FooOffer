using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FooOffer.Core.Entities
{
    public class Alternative : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(200)]
        public string Name { get; set; }
        
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; }
        
        [MaxLength(10)]
        public string Unit { get; set; }
        
        public decimal UnitPrice { get; set; }

        public bool IncludedByDefault { get; set; } = false;
    }
}