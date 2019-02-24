using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class HerbMedicinal : BaseEntity
    {
        [Required]
        public int HerbId { get; set; }
        public Herb Herb { get; set; }

        [Required]
        public int MedicinalDoseId { get; set; }
        public MedicinalDose MedicinalDose { get; set; }
    }
}