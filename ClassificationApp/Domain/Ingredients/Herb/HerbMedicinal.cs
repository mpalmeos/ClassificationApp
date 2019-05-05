using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class HerbMedicinal : DomainEntity
    {
        [Required]
        public int HerbId { get; set; }
        public Herb Herb { get; set; }

        [Required]
        public int MedicinalDoseId { get; set; }
        public MedicinalDose MedicinalDose { get; set; }

        [Required]
        public int HerbPartId { get; set; }
        public HerbPart HerbPart { get; set; }

        [Required]
        public int HerbFormId { get; set; }
        public HerbForm HerbForm { get; set; }
    }
}