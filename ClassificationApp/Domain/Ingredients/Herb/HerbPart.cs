using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class HerbPart : DomainEntity
    {
        [Required]
        public int HerbId { get; set; }
        public Herb Herb { get; set; }

        [Required]
        public int PlantPartId { get; set; }
        public PlantPart PlantPart { get; set; }

        public ICollection<HerbMedicinal> HerbMedicinals { get; set; }
    }
}