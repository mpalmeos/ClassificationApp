using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class ProductClassification
    {
        public int Id { get; set; }
        
        [MaxLength(32)]
        [MinLength(1)]
        [Required]
        public string ProductClassificationValue { get; set; }

        //public ICollection<Product> Products { get; set; }
    }
}