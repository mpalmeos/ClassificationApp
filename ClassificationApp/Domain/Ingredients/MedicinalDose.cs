using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class MedicinalDose : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        public string MedicinalDoseValue { get; set; }

        public ICollection<HerbMedicinal> HerbMedicinals { get; set; }

        public ICollection<SubstanceMedicinal> SubstanceMedicinals { get; set; }

        public int UnitOfMeasureId { get; set; }
        [Required]
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}