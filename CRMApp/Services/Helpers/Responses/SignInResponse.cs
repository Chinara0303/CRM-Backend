
namespace Services.Helpers.Responses
{
    public class SignInResponse
    {
        public string StatusMessage { get; set; }
        public List<string> Errors { get; set; }
        public string Token { get; set; }
    }
}
