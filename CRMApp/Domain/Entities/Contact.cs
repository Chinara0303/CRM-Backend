using Domain.Common;

namespace Domain.Entities
{
    public class Contact:BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int EducationId { get; set; }
        public string Message { get; set; }
    }
}
