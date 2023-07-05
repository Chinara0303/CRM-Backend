using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Account
{
    public class UserUpdateDto
    {
        [Required]
        public string Address { get; set; }
        [Required,Range(18,55)]
        public string Age { get; set; }
        [Required,Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Biography { get; set; }
        public IFormFile Photo { get; set; }
    }
}
