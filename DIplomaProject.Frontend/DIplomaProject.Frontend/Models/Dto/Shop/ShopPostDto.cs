using System.ComponentModel.DataAnnotations;

namespace DIplomaProject.Frontend.Models.Dto.Shop
{
    public class ShopPostDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Adress { get; set; }
    }
}
