using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FooOffer.Core.Entities
{
    public class City : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }
        
        [MaxLength(5)]
        public string Currency { get; set; }
        
        public IEnumerable<Alternative> Services { get; set; }
    }
}