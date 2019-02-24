

using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CompositionHerb : BaseEntity
    {
        [Required]
        public int HerbId { get; set; }
        public Herb Herb { get; set; }

        [Required]
        public int CompositionId { get; set; }
        public Composition Composition { get; set; }

        [Required]
        public int UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}