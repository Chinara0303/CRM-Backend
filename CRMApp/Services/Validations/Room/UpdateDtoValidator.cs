﻿using FluentValidation;
using Services.DTOs.Room;


namespace Services.Validations.Room
{
    public class UpdateDtoValidator:AbstractValidator<RoomUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(r => r.Capacity).NotNull().NotEmpty();
        }
    }
}
