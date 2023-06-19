using Domain.Common;
namespace Domain.Entities
{
    public class Seans:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Time> Times { get; set; }
    }
}
