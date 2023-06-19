﻿using Microsoft.AspNetCore.Http;
using Services.DTOs.Common;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Staff
{
    public class StaffUpdateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Range(18,65)]
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Biography { get; set; }
        public IFormFile Photo { get; set; }
    }
}
