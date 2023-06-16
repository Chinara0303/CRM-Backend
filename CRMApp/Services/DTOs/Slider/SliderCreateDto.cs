using Microsoft.AspNetCore.Http;

namespace Services.DTOs.Slider
{
    public class SliderCreateDto
    {
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
