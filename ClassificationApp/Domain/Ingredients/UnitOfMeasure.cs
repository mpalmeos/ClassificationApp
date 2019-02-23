using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UnitOfMeasure : BaseEntity
    {
        [MaxLength(32)]
        [MinLength(1)]
        [Required]
        public string UnitOfMeasureValue { get; set; }

        public ICollection<CompositionHerb> CompositionHerbs { get; set; }

        public ICollection<CompositionSubstance> CompositionSubstances { get; set; }

        public ICollection<MedicinalDose> MedicinalDoses { get; set; }
    }
}