using Domain.Common;

namespace Domain.Entities
{
    public class Room:BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
