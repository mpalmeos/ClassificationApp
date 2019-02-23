using System.Collections.Generic;

namespace Domain
{
    public class Composition : BaseEntity
    {
        public ICollection<ProductComposition> ProductCompositions { get; set; }

        public ICollection<CompositionHerb> CompositionHerbs { get; set; }

        public ICollection<CompositionSubstance> CompositionSubstances { get; set; }
    }
}