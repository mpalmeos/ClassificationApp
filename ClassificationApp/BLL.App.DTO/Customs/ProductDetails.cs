using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO.Customs
{
    public class ProductDetails
    {
        public int Id { get; set; }
        
        [Required]
        public int RouteOfAdministrationId { get; set; }
        public RouteOfAdministration RouteOfAdministration { get; set; }

        [Required]
        public int ProductClassificationId { get; set; }
        public ProductClassification ProductClassification { get; set; }

        [Required]
        public int ProductNameId { get; set; }
        public ProductName ProductName { get; set; }
        
        [Required]
        public int ProductCompanyId { get; set; }
        public ProductCompany ProductCompany { get; set; }
        
        [Required]
        public int ProductDescriptionId { get; set; }
        public ProductDescription ProductDescription { get; set; }
        
        [Required]
        public int ProductDosageId { get; set; }
        public ProductDosage ProductDosage { get; set; }
    }
}