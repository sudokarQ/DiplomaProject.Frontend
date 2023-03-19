using DIplomaProject.Frontend.Models.Enums;

namespace DIplomaProject.Frontend.Models.Dto.Order
{
    public class OrderGetDto
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public OrderStatus Status { get; set; }
        public TypeOrder Type { get; set; }
        public decimal TotaPrice { get; set; }
        public Guid ClientId { get; set; }
        public Guid ServiceId { get; set; }
    }
}
