using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CompanyRole : BaseEntity
    {
        [MaxLength(32)]
        [MinLength(1)]
        [Required]
        public string CompanyRoleValue { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}