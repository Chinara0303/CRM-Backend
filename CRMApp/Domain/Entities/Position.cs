using Domain.Common;

namespace Domain.Entities
{
    public class Position:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<StaffPosition> StaffPositions { get; set; }
    }
}
