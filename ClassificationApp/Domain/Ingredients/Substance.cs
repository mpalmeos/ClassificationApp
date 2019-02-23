using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Substance : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string SubstanceName { get; set; }

        [Required]
        public ICollection<SubstanceCategory> SubstanceCategories { get; set; }

        public ICollection<ProductComposition> ProductCompositions { get; set; }

        public ICollection<MedicinalDose> MedicinalDoses { get; set; }

        public int UnitOfMeasureId { get; set; }
        [Required]
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}