using Microsoft.AspNetCore.Http;

namespace Services.DTOs.Banner
{
    public class BannerCreateDto
    {
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Offer { get; set; }
    }
}
