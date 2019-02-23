using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductCompany : BaseEntity
    {
        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }

        public int CompanyId { get; set; }
        [Required]
        public Company Company { get; set; }
    }
}