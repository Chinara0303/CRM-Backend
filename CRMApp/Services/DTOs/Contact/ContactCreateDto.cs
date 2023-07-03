using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Contact
{
    public class ContactCreateDto
    {
        [Required]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,Phone]
        public string Phone { get; set; }
        [Required]
        public int EducationId { get; set; }
        
        public string Message { get; set; }
    }
}
