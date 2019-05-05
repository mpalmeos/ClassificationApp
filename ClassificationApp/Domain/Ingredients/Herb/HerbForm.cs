using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class HerbForm : DomainEntity
    {
        [Required]
        public int HerbId { get; set; }
        public Herb Herb { get; set; }

        [Required]
        public int PlantFormId { get; set; }
        public PlantForm PlantForm { get; set; }

        public ICollection<HerbMedicinal> HerbMedicinals { get; set; }
    }
}