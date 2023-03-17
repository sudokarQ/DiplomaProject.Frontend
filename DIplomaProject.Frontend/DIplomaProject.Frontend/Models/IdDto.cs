using System.ComponentModel.DataAnnotations;

namespace DIplomaProject.Frontend.Models
{
    public class IdDto
    {
        [Required]
        public Guid Id { get; set; }
    }
}
