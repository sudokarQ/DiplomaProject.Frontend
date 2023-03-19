using System.ComponentModel.DataAnnotations;

namespace DIplomaProject.Frontend.Models.Dto.Promotion
{
    public class PromotionPostDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 100)]
        public decimal DiscountPercent { get; set; }
        public bool IsCorporate { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Range(0, 100)]
        public decimal? CompanyPercent { get; set; }
        [Required]
        public Guid? ServiceId { get; set; }
    }
}
