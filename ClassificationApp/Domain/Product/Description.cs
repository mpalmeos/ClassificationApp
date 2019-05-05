using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Description : DomainEntity
    {
        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        public string DescriptionValue { get; set; }

        public ICollection<ProductDescription> ProductDescriptions { get; set; }
    }
}