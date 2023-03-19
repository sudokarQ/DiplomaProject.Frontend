using System.ComponentModel.DataAnnotations;

namespace DIplomaProject.Frontend.Models.Dto.Client
{
    public class ClientPostDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Surname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public DateTime? BirthdayDate { get; set; }
        public string Adress { get; set; }
        public string? CompanyName { get; set; }
    }
}
