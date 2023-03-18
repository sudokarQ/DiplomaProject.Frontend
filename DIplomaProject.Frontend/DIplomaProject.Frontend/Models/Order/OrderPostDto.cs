using DiplomaProject.Backend.Common.DataBaseConfigurations;
using DiplomaProject.Backend.Common.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.Order
{
    public class OrderPostDto
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        public TypeOrder Type { get; set; }
        [Required]
        public Guid ClientId { get; set; }
        [Required]
        public Guid ServiceId { get; set; }
    }
}
