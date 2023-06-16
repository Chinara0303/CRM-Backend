using Services.DTOs.Common;
namespace Services.DTOs.Banner
{
    public class BannerDto:ActionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Offer { get; set; }
        public string Image { get; set; }
    }
}
