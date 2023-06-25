using Services.DTOs.Common;

namespace Services.DTOs.About
{
    public class AboutListDto:ActionDto
    {
        public int Id { get; set; }
        public List<string> Image { get; set; } 
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}
