using Domain.Helpers.Enums;

namespace Services.DTOs.Group
{
    public class GroupCreateDto
    {
        public int RoomId { get; set; }
        public int EducationId { get; set; }
        public Weekday Weekday { get; set; }
        public int TimeId { get; set; }
    }
}
