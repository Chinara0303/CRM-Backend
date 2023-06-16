using Services.DTOs.Common;

namespace Services.DTOs.Slider
{
    public class SliderListDto:ActionDto
    {
        public int Id { get; set; }
        public List<string> Images { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
