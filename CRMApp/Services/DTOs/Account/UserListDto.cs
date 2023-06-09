﻿namespace Services.DTOs.Account
{
    public class UserListDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Biography { get; set; }
        public List<string> RoleNames { get; set; } = new();
        public bool SoftDelete { get; set; }
        public bool IsActive { get; set; }
        public List<string> Image { get; set; }

    }
}
