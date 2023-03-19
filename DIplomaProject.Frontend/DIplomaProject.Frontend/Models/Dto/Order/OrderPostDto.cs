using DIplomaProject.Frontend.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DIplomaProject.Frontend.Models.Dto.Order
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
