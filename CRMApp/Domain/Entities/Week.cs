using Domain.Common;
using Domain.Helpers.Enums;
namespace Domain.Entities
{
    public class Week:BaseEntity
    {
        public string Name { get; set; }
        public Weekday Weekday { get; set; }

    }
}
