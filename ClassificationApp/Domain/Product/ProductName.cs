using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductName : DomainEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string ProductNameValue { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}