using Domain.Helpers.Enums;
using Services.DTOs.Common;
using Services.DTOs.Course;
using Services.DTOs.Room;

namespace Services.DTOs.Group
{
    public class GroupListDto:ActionDto
    {
        public string Name { get; set; }
        public RoomDto Room { get; set; }
        public CourseDto Course { get; set; }
        public Weekday Weekday { get; set; }
        public Seans Seans { get; set; }
    }
}
