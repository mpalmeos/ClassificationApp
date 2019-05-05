using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductCompany : DomainEntity
    {
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}