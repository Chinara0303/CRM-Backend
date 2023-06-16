using Services.DTOs.Common;
using Services.DTOs.Group;

namespace Services.DTOs.Room
{
    public class RoomDto : ActionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GroupDto> Groups { get; set; }
    }
}
