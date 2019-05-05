using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductComposition : DomainEntity
    {
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int CompositionId { get; set; }
        public Composition Composition { get; set; }
    }
}