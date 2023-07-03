using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Subscribe
{
    public class SubscribeCreateDto
    {
        [Required,EmailAddress]
        public string Email { get; set; }
    }
}
