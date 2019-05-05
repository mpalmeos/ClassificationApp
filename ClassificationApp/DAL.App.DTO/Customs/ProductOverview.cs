using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO.Customs
{
    public class ProductOverview
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
    }
}