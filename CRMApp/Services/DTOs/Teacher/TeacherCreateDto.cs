using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Teacher
{
    public class TeacherCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Range(22, 55)]
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Biography { get; set; }
        public IFormFile Photo { get; set; }
    }
}
