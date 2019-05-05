using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
{
    public class Company
    {
        public int Id { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string CompanyName { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
        public string CompanyAddress { get; set; }

        //public ICollection<CompanyRole> CompanyRoles { get; set; }

        //public ICollection<ProductCompany> ProductCompanies { get; set; }
    }
}