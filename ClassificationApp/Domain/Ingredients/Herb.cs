using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Herb : BaseEntity
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

        [Required]
        public ICollection<HerbPart> HerbParts { get; set; }

        [Required]
        public ICollection<HerbForm> HerbForms { get; set; }

        public ICollection<ProductComposition> ProductCompositions { get; set; }

        public ICollection<MedicinalDose> MedicinalDoses { get; set; }

        public int UnitOfMeasureId { get; set; }
        [Required]
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}