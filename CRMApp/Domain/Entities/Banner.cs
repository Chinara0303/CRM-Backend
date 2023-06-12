using Domain.Common;

namespace Domain.Entities
{
    public class Banner : BaseEntity
    {
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Offer { get; set; }
    }
}
