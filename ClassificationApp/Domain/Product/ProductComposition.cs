using System.Collections.Generic;

namespace Domain
{
    public class ProductComposition : BaseEntity
    {
        public ICollection<Product> Products { get; set; }

        public ICollection<Substance> Substances { get; set; }

        public ICollection<Herb> Herbs { get; set; }
    }
}