﻿
using Microsoft.AspNetCore.Http;

namespace Services.DTOs.Course
{
    public class CourseUpdateDto
    {
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Promise { get; set; }
        public string Duration { get; set; }
    }
}
