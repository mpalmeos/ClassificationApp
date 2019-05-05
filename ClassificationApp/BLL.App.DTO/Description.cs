using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class Description
    {
        public int Id { get; set; }
        
        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        public string DescriptionValue { get; set; }

        //public ICollection<ProductDescription> ProductDescriptions { get; set; }
    }
}