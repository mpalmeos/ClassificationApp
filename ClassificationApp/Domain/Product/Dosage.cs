using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Dosage : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string DosageValue { get; set; }

        public ICollection<ProductDosage> ProductDosages { get; set; }
    }
}