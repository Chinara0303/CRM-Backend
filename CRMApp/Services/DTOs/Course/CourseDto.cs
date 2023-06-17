using Services.DTOs.Common;
using Services.DTOs.Group;

namespace Services.DTOs.Course
{
    public class CourseDto:ActionDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Promise { get; set; }
        public string Duration { get; set; }
        public int GroupCount{ get; set; }
        public List<int> GroupIds { get; set; } = new List<int>();
    }
}
