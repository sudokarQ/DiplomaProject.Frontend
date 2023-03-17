using System.ComponentModel.DataAnnotations;

namespace DIplomaProject.Frontend.Models.Client
{
    public class ClientPutDto
    {
        [Required]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? CompanyName { get; set; }
    }
}
