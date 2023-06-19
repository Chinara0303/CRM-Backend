﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Student
{
    public class StudentUpdateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Range(15, 55)]
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Biography { get; set; }
        public IFormFile Photo { get; set; }
        public int GroupId { get; set; }
    }
}