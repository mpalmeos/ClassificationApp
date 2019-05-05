using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
{
    public class CRole
    {
        public int Id { get; set; }
        
        [MaxLength(32)]
        [MinLength(1)]
        [Required]
        public string RoleValue { get; set; }

        //public ICollection<CompanyRole> CompanyRoles { get; set; }
    }
}