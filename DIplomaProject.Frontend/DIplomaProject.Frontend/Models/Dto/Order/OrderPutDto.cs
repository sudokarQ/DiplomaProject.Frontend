using DIplomaProject.Frontend.Models.Dto;
using DIplomaProject.Frontend.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DIplomaProject.Frontend.Models.Dto.Order
{
    public class OrderPutDto : IdDto
    {
        [Required]
        public Guid Id { get; set; }
        public OrderStatus? Status { get; set; }
        public TypeOrder? Type { get; set; }
        [Range(0, int.MaxValue)]
        public decimal? TotaPrice { get; set; }
    }
}
