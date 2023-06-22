using Domain.Common;

namespace Domain.Entities
{
    public class TeacherGroup:BaseEntity
    {
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public Teacher Teacher { get; set; }
      
    }
}
