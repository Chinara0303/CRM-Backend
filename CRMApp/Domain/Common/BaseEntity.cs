
namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(4);
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow.AddHours(4);
        public DateTime DeletedDate { get; set; } = DateTime.UtcNow.AddHours(4);
        public bool SoftDelete { get; set; } = false;
    }
}
