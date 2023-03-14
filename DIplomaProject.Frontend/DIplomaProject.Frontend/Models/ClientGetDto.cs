namespace DIplomaProject.Frontend.Models
{
    public class ClientGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthdayDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? Adress { get; set; }
        public string? CompanyName { get; set; }
        public Guid UserId { get; set; }
    }
}
