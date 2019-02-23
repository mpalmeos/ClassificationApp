using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Category : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string CategoryValue { get; set; }

        public ICollection<SubstanceCategory> SubstanceCategories { get; set; }
    }
}