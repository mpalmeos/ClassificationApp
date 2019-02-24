using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CompanyRole : BaseEntity
    {
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}