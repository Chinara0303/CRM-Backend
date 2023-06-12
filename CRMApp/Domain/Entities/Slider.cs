using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Slider:BaseEntity
    {
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
