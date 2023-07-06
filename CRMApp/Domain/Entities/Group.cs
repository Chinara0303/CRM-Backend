using Domain.Common;
using Domain.Helpers.Enums;

namespace Domain.Entities
{
    public class Group:BaseEntity
    {
        public string Name { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int EducationId { get; set; }
        public Education Education { get; set; }
        public Weekday Weekday { get; set; }
        public int TimeId { get; set; }
        public Time Time { get; set; }
        public ICollection<Student> Students { get; set; }
        public List<TeacherGroup> TeacherGroups { get; set; }
    }
}

