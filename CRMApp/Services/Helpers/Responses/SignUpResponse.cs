using Domain.Entities;

namespace Services.Helpers.Responses
{
    public class SignUpResponse
    {
        public List<string> Errors { get; set; } = new List<string>();
        public string StatusMessage { get; set; }
        public AppUser User { get; set; } = new AppUser();
    }
}
