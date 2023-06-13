using Domain.Common;

namespace Domain.Entities
{
    public class Group:BaseEntity
    {
        public string Name { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int SeansId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
