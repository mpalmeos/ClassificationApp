using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class HerbForm : BaseEntity
    {
        public int HerbId { get; set; }
        [Required]
        public Herb Herb { get; set; }

        public int PlantFormId { get; set; }
        [Required]
        public PlantForm PlantForm { get; set; }
    }
}