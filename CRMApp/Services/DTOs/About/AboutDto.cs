using Services.DTOs.Common;

namespace Services.DTOs.About
{
    public class AboutDto:ActionDto
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}
