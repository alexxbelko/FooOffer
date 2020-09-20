using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FooOffer.Core.Entities
{
    public class OfferItem : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [ForeignKey(nameof(Alternative))]
        public int ServiceId { get; set; }
        public Alternative Alternative { get; set; }

        public decimal Amount { get; set; }

        public decimal ItemSum { get; set; }
    }
}