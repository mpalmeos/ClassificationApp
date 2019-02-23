using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class HerbMedicinal : BaseEntity
    {
        public int HerbId { get; set; }
        [Required]
        public Herb Herb { get; set; }

        public int MedicinalDoseId { get; set; }
        [Required]
        public MedicinalDose MedicinalDose { get; set; }
    }
}