using Services.DTOs.Common;

namespace Services.DTOs.About
{
    public class AboutDto:ActionDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}
