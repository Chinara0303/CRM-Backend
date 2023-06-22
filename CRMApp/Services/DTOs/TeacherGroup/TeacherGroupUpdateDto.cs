
namespace Services.DTOs.TeacherGroup
{
    public class TeacherGroupUpdateDto
    {
        public int GroupId { get; set; }
        public List<int> TeacherIds { get; set; } = new List<int>();
    }
}
