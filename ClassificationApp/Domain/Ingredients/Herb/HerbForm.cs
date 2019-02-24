using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class HerbForm : BaseEntity
    {
        [Required]
        public int HerbId { get; set; }
        public Herb Herb { get; set; }

        [Required]
        public int PlantFormId { get; set; }
        public PlantForm PlantForm { get; set; }
    }
}