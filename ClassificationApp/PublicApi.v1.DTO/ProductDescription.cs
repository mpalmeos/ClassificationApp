using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
{
    public class ProductDescription
    {
        public int Id { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int DescriptionId { get; set; }
        public Description Description { get; set; }
    }
}