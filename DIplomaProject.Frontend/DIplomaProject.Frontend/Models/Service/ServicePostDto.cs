using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.Service
{
    public class ServicePostDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string TypeService { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Некорректная стоимость")]
        public decimal Price { get; set; }
        public Guid ShopId { get; set; }
    }
}
