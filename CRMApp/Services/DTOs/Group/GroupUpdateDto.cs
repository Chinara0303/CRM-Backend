using Domain.Helpers.Enums;

namespace Services.DTOs.Group
{
    public class GroupUpdateDto
    {
        public int RoomId { get; set; }
        public List<int> TeacherIds { get; set; }
    }
}
