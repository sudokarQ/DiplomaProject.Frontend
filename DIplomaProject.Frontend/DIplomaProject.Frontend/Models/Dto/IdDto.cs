using System.ComponentModel.DataAnnotations;

namespace DIplomaProject.Frontend.Models.Dto
{
    public class IdDto
    {
        [Required]
        public Guid Id { get; set; }
    }
}
