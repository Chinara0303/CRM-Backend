using Services.DTOs.Common;

namespace Services.DTOs.TeacherGroup
{
    public class TeacherGroupDto:ActionDto
    {
        public int GroupId { get; set; }
        public List<int> TeacherIds { get; set; } = new List<int>();
    }
}
