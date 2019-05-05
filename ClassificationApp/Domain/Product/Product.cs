using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Product : DomainEntity
    {
        public ICollection<ProductCompany> ProductCompanies { get; set; }

        [Required]
        public int RouteOfAdministrationId { get; set; }
        public RouteOfAdministration RouteOfAdministration { get; set; }

        [Required]
        public int ProductClassificationId { get; set; }
        public ProductClassification ProductClassification { get; set; }

        [Required]
        public int ProductNameId { get; set; }
        public ProductName ProductName { get; set; }

        public ICollection<ProductDescription> ProductDescriptions { get; set; }

        public ICollection<ProductDosage> ProductDosages { get; set; }

        public ICollection<ProductComposition> ProductCompositions { get; set; }
        
    }
}