using Services.DTOs.Common;


namespace Services.DTOs.Contact
{
    public class ContactDto:ActionDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string EducationName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

    }
}
