using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Teacher
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Biography { get; set; }
        public List<int> GroupIds { get; set; } = new List<int>();
        public string Image { get; set; }
    }
}
