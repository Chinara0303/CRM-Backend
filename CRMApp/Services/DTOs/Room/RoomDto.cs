using Services.DTOs.Common;
using Services.DTOs.Group;

namespace Services.DTOs.Room
{
    public class RoomDto : ActionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int GroupCount { get; set; }
        public List<int> GroupIds { get; set; } = new List<int>();
    }
}
