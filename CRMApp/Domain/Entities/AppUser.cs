using Microsoft.AspNetCore.Identity;


namespace Domain.Entities
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Biography { get; set; }
        public byte[] Image { get; set; }
        public int Age { get; set; }
        public bool SoftDelete { get; set; }
        public bool IsRememberMe { get; set; }
        public bool IsActive { get; set; }
    }
}
