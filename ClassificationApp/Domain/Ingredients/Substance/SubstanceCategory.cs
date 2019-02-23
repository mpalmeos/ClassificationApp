using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class SubstanceCategory : BaseEntity
    {
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }

        public int SubstanceId { get; set; }
        [Required]
        public Substance Substance { get; set; }
    }
}