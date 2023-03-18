using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.ShopUser
{
    public class ShopUserPostDto
    {
        public Guid Id { get; set; }
        [Required]
        public Guid ShopId { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
