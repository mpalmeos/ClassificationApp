using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class SubstanceCategory : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string SubstanceCategoryValue { get; set; }

        public ICollection<Substance> Substances { get; set; }
    }
}