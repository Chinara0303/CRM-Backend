using Services.DTOs.Common;

namespace Services.DTOs.Social
{
    public class StaffSocialDto:ActionDto
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public int StaffId { get; set; }
    }
}
