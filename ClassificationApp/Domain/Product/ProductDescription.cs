using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductDescription : BaseEntity
    {
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int DescriptionId { get; set; }
        public Description Description { get; set; }
    }
}