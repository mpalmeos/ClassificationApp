using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class HerbPart : BaseEntity
    {
        public int HerbId { get; set; }
        [Required]
        public Herb Herb { get; set; }

        public int PlantPartId { get; set; }
        [Required]
        public PlantPart PlantPart { get; set; }
    }
}