using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class ProductDosage
    {
        public int Id { get; set; }
        
        [Required]
        public int DosageId { get; set; }
        public Dosage Dosage { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}