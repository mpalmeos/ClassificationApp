using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
{
    public class CompanyRole
    {
        public int Id { get; set; }
        
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required] 
        public int CRoleId { get; set; }
        public CRole CRole { get; set; }
    }
}