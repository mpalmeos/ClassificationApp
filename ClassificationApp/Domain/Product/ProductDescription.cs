using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductDescription : BaseEntity
    {
        [MaxLength(255)]
        [MinLength(1)]
        public string ProductDescriptionValue { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}