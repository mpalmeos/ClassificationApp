using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class Product
    {
        public int Id { get; set; }
        
        //public ICollection<ProductCompany> ProductCompanies { get; set; }

        [Required]
        public int RouteOfAdministrationId { get; set; }
        public RouteOfAdministration RouteOfAdministration { get; set; }

        [Required]
        public int ProductClassificationId { get; set; }
        public ProductClassification ProductClassification { get; set; }

        [Required]
        public int ProductNameId { get; set; }
        public ProductName ProductName { get; set; }

        //public ICollection<ProductDescription> ProductDescriptions { get; set; }

        //public ICollection<ProductDosage> ProductDosages { get; set; }

        //public ICollection<ProductComposition> ProductCompositions { get; set; }
        
    }
}