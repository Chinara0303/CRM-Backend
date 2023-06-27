using Services.DTOs.Common;
using Services.DTOs.Group;

namespace Services.DTOs.Education
{
    public class EducationListDto : ActionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Promise { get; set; }
        public string Duration { get; set; }
        public List<int> GroupIds { get; set; } = new List<int>();
        public int GroupCount { get; set; }
    }
}
