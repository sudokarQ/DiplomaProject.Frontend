using DiplomaProject.Backend.Common.DataBaseConfigurations;
using DiplomaProject.Backend.Common.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.Order
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
