using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductComposition : BaseEntity
    {
        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }

        public int CompositionId { get; set; }
        [Required]
        public Composition Composition { get; set; }
    }
}