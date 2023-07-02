using Domain.Entities;

namespace Services.DTOs.Teacher
{
    public class TeacherListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Biography { get; set; }
        public List<Domain.Entities.Group> Groups { get; set; } = new List<Domain.Entities.Group>();
        public List<string> Image { get; set; } 
    }
}
