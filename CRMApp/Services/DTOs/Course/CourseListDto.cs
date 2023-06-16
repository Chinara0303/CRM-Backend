﻿using Services.DTOs.Common;
using Services.DTOs.Group;

namespace Services.DTOs.Course
{
    public class CourseListDto:ActionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Images { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Promise { get; set; }
        public string Duration { get; set; }
        public ICollection<GroupDto> Groups { get; set; }
    }
}