using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.Shop
{
    public class ShopPutDto : IdDto
    {
        [Required]
        public Guid Id { get; set; }
        [StringLength(30)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }
    }
}
