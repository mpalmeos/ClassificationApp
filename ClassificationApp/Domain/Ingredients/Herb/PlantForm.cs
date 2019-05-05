using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PlantForm : DomainEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string PlantFormValueLatin { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string PlantFormValueEstonian { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        public string PlantFormValueEnglish { get; set; }

        public ICollection<HerbForm> HerbForms { get; set; }
    }
}