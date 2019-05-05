using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
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