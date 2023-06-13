
namespace Services.DTOs.Common
{
    public class ActionDto
    {
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string DeletedDate { get; set; }
        public bool SoftDelete { get; set; }
    }
}
