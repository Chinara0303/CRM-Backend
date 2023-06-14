using Microsoft.AspNetCore.Http;

namespace Services.DTOs.Course
{
    public class CourseCreateDto
    {
        public IFormFile Photo { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Promise { get; set; }
        public string Duration { get; set; }
    }
}
