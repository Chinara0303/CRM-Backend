using Domain.Common;

namespace Domain.Entities
{
    public class Staff:CommonPerson
    {
        public ICollection<StaffPosition> StaffPositions { get; set; }
    }
}
