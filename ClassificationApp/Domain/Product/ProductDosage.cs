using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductDosage : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string ProductDosageValue { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}