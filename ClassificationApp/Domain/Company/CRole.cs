using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CRole : DomainEntity
    {
        [MaxLength(32)]
        [MinLength(1)]
        [Required]
        public string RoleValue { get; set; }

        public ICollection<CompanyRole> CompanyRoles { get; set; }
    }
}