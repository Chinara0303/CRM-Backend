using Domain.Helpers.Enums;

namespace Services.DTOs.Group
{
    public class GroupCreateDto
    {
        public int RoomId { get; set; }
        public int CourseId { get; set; }
        public Weekday Weekday { get; set; }
        public Seans Seans { get; set; }
        //public string Name { get; set; }
    }
}
