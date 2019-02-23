using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class HerbPart : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string HerbPartValueLatin { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string HerbPartValueEstonian { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string HerbPartValueEnglish { get; set; }

        public ICollection<Herb> Herbs { get; set; }
    }
}