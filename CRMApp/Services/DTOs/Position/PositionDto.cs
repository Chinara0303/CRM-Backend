﻿using Services.DTOs.Common;

namespace Services.DTOs.Position
{
    public class PositionDto : ActionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
