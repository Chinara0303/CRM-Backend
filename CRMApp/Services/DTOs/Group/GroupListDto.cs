﻿using Domain.Helpers.Enums;
using Services.DTOs.Common;

namespace Services.DTOs.Group
{
    public class GroupListDto:ActionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public int EducationId { get; set; }
        public int TimeId { get; set; }
        public Weekday Weekday { get; set; }
        public int StudentsCount { get; set; }
        public List<int> TeacherIds { get; set; } = new List<int>();
    }
}
