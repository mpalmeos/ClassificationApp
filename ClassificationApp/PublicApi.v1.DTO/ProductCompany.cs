using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
{
    public class ProductCompany
    {
        public int Id { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}