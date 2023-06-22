namespace Services.DTOs.TeacherGroup
{
    public class TeacherGroupCreateDto
    {
        public int GroupId { get; set; }
        public List<int> TeacherIds { get; set; }
    }
}
