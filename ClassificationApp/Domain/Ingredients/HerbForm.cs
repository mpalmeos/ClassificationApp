using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class HerbForm : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string HerbFormValueLatin { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string HerbFormValueEstonian { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string HerbFormValueEnglish { get; set; }

        public ICollection<Herb> Herbs { get; set; }
    }
}