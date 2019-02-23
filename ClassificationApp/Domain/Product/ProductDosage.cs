using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductDosage : BaseEntity
    {
        public int DosageId { get; set; }
        [Required]
        public Dosage Dosage { get; set; }

        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }
    }
}