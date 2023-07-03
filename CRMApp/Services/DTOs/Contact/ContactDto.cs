using Services.DTOs.Common;


namespace Services.DTOs.Contact
{
    public class ContactDto:ActionDto
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int EducationId { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

    }
}
