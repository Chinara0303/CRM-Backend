using Services.DTOs.Common;

namespace Services.DTOs.Banner
{
    public class BannerListDto:ActionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Offer { get; set; }
        public List<string> Images { get; set; }
    }
}
