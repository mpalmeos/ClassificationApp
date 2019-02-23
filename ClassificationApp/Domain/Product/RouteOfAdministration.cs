using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class RouteOfAdministration : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string RouteOfAdministrationValue { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}