using Microsoft.AspNetCore.Http;

namespace Services.DTOs.About
{
    public class AboutUpdateDto
    {
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}
