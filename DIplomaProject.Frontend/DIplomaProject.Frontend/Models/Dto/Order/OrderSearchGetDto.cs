namespace DIplomaProject.Frontend.Models.Dto.Order
{
    public class OrderSearchGetDto
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
