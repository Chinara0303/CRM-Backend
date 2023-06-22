namespace Services.DTOs.Contact
{
    public class ContactCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int EducationId { get; set; }
        public string Message { get; set; }
    }
}
