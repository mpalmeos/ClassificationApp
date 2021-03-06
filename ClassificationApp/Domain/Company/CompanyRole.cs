using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CompanyRole : DomainEntity
    {
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required] 
        public int CRoleId { get; set; }
        public CRole CRole { get; set; }
    }
}