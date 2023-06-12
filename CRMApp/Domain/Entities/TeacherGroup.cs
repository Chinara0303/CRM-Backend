using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TeacherGroup:BaseEntity
    {
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public Teacher Teacher { get; set; }
    }
}
