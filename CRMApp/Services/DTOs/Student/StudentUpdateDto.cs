using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Student
{
    public class StudentUpdateDto
    {
        [Required]
        public string FullName { get; set; }
        [Required ,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required,Range(15, 55)]
        public string Age { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Biography { get; set; }
        public IFormFile Photo { get; set; }
        [Required]
        public int GroupId { get; set; }
    }
}
