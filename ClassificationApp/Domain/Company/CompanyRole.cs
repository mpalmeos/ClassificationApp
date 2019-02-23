using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CompanyRole : BaseEntity
    {
        public int CompanyId { get; set; }
        [Required]
        public Company Company { get; set; }

        public int RoleId { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}