using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PlantPart : DomainEntity
    {
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string PlantPartValueLatin { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string PlantPartValueEstonian { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string PlantPartValueEnglish { get; set; }
        
        public ICollection<HerbPart> HerbParts { get; set; }
    }
}