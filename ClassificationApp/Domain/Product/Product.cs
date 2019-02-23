using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Product : BaseEntity
    {
        [Required]
        public ICollection<ProductCompany> ProductCompanies { get; set; }

        public int RouteOfAdministrationId { get; set; }
        [Required]
        public RouteOfAdministration RouteOfAdministration { get; set; }

        public int ProductClassificationId { get; set; }
        [Required]
        public ProductClassification ProductClassification { get; set; }

        public int ProductNameId { get; set; }
        [Required]
        public ProductName ProductName { get; set; }

        public ICollection<ProductDescription> ProductDescriptions { get; set; }

        [Required]
        public ICollection<ProductDosage> ProductDosages { get; set; }

        [Required]
        public ICollection<ProductComposition> ProductCompositions { get; set; }
        
    }
}