using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public class RouteOfAdministration
    {
        public int Id { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string RouteOfAdministrationValue { get; set; }

        //public ICollection<Product> Products { get; set; }
    }
}