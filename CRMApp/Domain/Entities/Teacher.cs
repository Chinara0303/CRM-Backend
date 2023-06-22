using Domain.Common;

namespace Domain.Entities
{
    public class Teacher:CommonPerson
    {
        public ICollection<TeacherGroup> TeacherGroups { get; set; }
    }
}
