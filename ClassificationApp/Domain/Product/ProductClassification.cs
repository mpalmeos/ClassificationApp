using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductClassification : BaseEntity
    {
        [MaxLength(32)]
        [MinLength(1)]
        [Required]
        public string ProductClassificationValue { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}