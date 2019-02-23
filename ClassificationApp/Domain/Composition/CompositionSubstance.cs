using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CompositionSubstance : BaseEntity
    {
        public int SubstanceId { get; set; }
        [Required]
        public Substance Substance { get; set; }

        public int CompositionId { get; set; }
        [Required]
        public Composition Composition { get; set; }

        public int UnitOfMeasureId { get; set; }
        [Required]
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}