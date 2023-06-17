using Domain.Helpers.Enums;
using Services.DTOs.Common;

namespace Services.DTOs.Group
{
    public class GroupDto:ActionDto
    {
        public string Name { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int EducationId { get; set; }
        public string EducationName { get; set; }
        public Weekday Weekday { get; set; }
        public Seans Seans { get; set; }
    }
}
