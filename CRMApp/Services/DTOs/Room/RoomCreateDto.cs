
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Room
{
    public class RoomCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Range(8,15)]
        public int Capacity { get; set; }
    }
}
