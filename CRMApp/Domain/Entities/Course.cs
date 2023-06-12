using Domain.Common;

namespace Domain.Entities
{
    public class Course:BaseEntity
    {
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public decimal Price { get; set; }
        public decimal Description { get; set; }
        public string Promise { get; set; }
        public string Duration { get; set; }
    }
}
