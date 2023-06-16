using Domain.Common;

namespace Domain.Entities
{
    public class Social : BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}
