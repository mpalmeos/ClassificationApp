using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class SubstanceMedicinal : DomainEntity
    {
        [Required]
        public int SubstanceId { get; set; }
        public Substance Substance { get; set; }

        [Required]
        public int MedicinalDoseId { get; set; }
        public MedicinalDose MedicinalDose { get; set; }
    }
}