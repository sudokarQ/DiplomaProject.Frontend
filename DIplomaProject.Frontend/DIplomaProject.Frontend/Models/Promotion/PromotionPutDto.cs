using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.Promotion
{
    public class PromotionPutDto : IdDto
    {
        [Required]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Range(0, 100)]
        public decimal? DiscountPercent { get; set; }
        public Guid? ServiceId { get; set; }
    }
}
