using Services.DTOs.Common;

namespace Services.DTOs.Time
{
    public class TimeDto:ActionDto
    {
        public int Id { get; set; }
        public string Interval { get; set; }
    }
}
