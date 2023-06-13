using Domain.Common;

namespace Domain.Entities
{
    public class About : BaseEntity
    {
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}
