using Microsoft.AspNetCore.Http;

namespace Services.DTOs.Education
{
    public class EducationCreateDto
    {
        public IFormFile Photo { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Promise { get; set; }
        public string Duration { get; set; }
    }
}
