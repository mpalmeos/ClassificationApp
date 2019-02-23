using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class SubstanceMedicinal : BaseEntity
    {
        public int SubstanceId { get; set; }
        [Required]
        public Substance Substance { get; set; }

        public int MedicinalDoseId { get; set; }
        [Required]
        public MedicinalDose MedicinalDose { get; set; }
    }
}