using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductDescription : BaseEntity
    {
        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }

        public int DescriptionId { get; set; }
        [Required]
        public Description Description { get; set; }
    }
}