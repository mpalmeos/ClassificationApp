using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductDosage : BaseEntity
    {
        [Required]
        public int DosageId { get; set; }
        public Dosage Dosage { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}