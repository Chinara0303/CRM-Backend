using Domain.Common;

namespace Domain.Entities
{
    public class StaffSocial:BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}
