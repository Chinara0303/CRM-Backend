using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Education
{
    public class EducationCreateDto
    {
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required,Range(1000,10000)]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Promise { get; set; }
        [Required]
        public string Duration { get; set; }
    }
}
