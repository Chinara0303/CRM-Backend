using Domain.Common;

namespace Domain.Entities
{
    public class Education:BaseEntity
    {
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }         
        public string Promise { get; set; }
        public string Duration { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
