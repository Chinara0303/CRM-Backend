using Services.DTOs.Common;


namespace Services.DTOs.SiteSocial
{
    public class SiteSocialDto:ActionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }
        public string Link { get; set; }
    }
}
