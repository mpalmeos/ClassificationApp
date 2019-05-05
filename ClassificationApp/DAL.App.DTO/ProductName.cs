using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class ProductName
    {
        public int Id { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string ProductNameValue { get; set; }

        //public ICollection<Product> Products { get; set; }
    }
}