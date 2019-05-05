using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CompositionSubstance : DomainEntity
    {
        [Required]
        public int SubstanceId { get; set; }
        public Substance Substance { get; set; }
        
        [Required]
        public int CompositionId { get; set; }
        public Composition Composition { get; set; }

        [Required]
        public int UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}