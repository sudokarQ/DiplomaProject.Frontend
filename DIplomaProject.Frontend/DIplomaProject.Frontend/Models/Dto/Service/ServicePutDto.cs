using System.ComponentModel.DataAnnotations;

namespace DIplomaProject.Frontend.Models.Dto.Service
{
    public class ServicePutDto : IdDto
    {
        [Required]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Некорректная стоимость")]
        public decimal? Price { get; set; }
    }
}
