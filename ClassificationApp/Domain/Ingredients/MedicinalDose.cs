using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class MedicinalDose : DomainEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string MedicinalDoseValue { get; set; }

        public ICollection<HerbMedicinal> HerbMedicinals { get; set; }

        public ICollection<SubstanceMedicinal> SubstanceMedicinals { get; set; }

        [Required]
        public int UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}