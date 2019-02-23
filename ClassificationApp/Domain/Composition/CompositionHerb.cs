

using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CompositionHerb : BaseEntity
    {
        public int HerbId { get; set; }
        [Required]
        public Herb Herb { get; set; }

        public int CompositionId { get; set; }
        [Required]
        public Composition Composition { get; set; }

        public int UnitOfMeasureId { get; set; }
        [Required]
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}