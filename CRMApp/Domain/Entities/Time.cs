using Domain.Common;

namespace Domain.Entities
{
    public class Time:BaseEntity
    {
        public string Interval { get; set; }
        public  int SeansId { get; set; }
        public Seans Seans { get; set; }
    }
}
