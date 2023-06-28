using Services.DTOs.Common;

namespace Services.DTOs.Time
{
    public class TimeDto:ActionDto
    {
        public int Id { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int SeansId { get; set; }
    }
}
