﻿using Microsoft.AspNetCore.Identity;


namespace Domain.Entities
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
