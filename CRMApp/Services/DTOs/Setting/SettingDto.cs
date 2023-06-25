
using Services.DTOs.Common;

namespace Services.DTOs.Setting
{
    public class SettingDto:ActionDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
