using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
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