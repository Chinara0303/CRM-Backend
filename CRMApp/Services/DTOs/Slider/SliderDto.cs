using Services.DTOs.Common;
namespace Services.DTOs.Slider
{
    public class SliderDto:ActionDto
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
