using Domain.Common;

namespace Domain.Entities
{
    public class SiteSocial:BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string IconName { get; set; }
    }
}
