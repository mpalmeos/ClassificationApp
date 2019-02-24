using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class HerbPart : BaseEntity
    {
        [Required]
        public int HerbId { get; set; }
        public Herb Herb { get; set; }

        [Required]
        public int PlantPartId { get; set; }
        public PlantPart PlantPart { get; set; }
    }
}