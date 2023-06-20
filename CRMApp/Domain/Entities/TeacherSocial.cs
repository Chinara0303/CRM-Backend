using Domain.Common;

namespace Domain.Entities
{
    public class TeacherSocial : BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
