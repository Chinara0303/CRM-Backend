using Domain.Common;

namespace Domain.Entities
{
    public class StaffPosition:BaseEntity
    {
        public int StaffId { get; set; }
        public int PositionId { get; set; }
        public Staff Staff { get; set; }
        public Position Position { get; set; }
    }
}
