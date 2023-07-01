using Domain.Common;

namespace Domain.Entities
{
    public class Student : CommonPerson
    {
        public int GroupId { get; set; }
        public Group Group { get; set; } 
    }
}
