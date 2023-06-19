using Services.DTOs.Common;

namespace Services.DTOs.Social
{
    public class SocialDto:ActionDto
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
    }
}
