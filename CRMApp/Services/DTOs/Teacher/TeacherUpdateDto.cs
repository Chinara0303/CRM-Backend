using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Teacher
{
    public class TeacherUpdateDto
    {
        [Required]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required,Range(22, 55)]
        public string Age { get; set; }
        [Required,Phone]
        public string Phone { get; set; }
        [Required]
        public string Biography { get; set; }
        public IFormFile Photo { get; set; }
    }
}
