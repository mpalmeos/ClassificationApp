using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class SubstanceCategory : BaseEntity
    {
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public int SubstanceId { get; set; }
        public Substance Substance { get; set; }
    }
}