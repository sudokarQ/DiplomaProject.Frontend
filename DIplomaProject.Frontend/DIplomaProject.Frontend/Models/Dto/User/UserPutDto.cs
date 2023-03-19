using System.ComponentModel.DataAnnotations;

namespace DIplomaProject.Frontend.Models.Dto.User
{
    public class UserPutDto : IdDto
    {
        [Required]
        public Guid Id { get; set; }
        //public string? Login { get; set; }
        //public string? Password { get; set; }
    }
}
