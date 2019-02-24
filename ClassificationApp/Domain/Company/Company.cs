using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Company : BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string CompanyName { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
        public string CompanyAddress { get; set; }

        public ICollection<CompanyRole> CompanyRoles { get; set; }

        public ICollection<ProductCompany> ProductCompanies { get; set; }
    }
}