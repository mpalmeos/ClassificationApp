using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Herb : DomainEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string HerbNameLatin { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string HerbNameEstonian { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string HerbNameEnglish { get; set; }

        public ICollection<HerbPart> HerbParts { get; set; }

        public ICollection<HerbForm> HerbForms { get; set; }

        public ICollection<CompositionHerb> CompositionHerbs { get; set; }

        public ICollection<HerbMedicinal> HerbMedicinals { get; set; }
    }
}