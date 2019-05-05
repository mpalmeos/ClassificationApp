using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class Dosage
    {
        public int Id { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string DosageValue { get; set; }

        //public ICollection<ProductDosage> ProductDosages { get; set; }
    }
}