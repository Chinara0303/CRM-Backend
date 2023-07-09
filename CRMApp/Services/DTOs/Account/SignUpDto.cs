using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Account
{
    public class SignUpDto
    {
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Biography { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public List<string> RoleIds { get; set; }
    }
}
