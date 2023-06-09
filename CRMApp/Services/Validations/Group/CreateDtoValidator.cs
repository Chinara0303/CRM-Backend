﻿
using FluentValidation;
using Services.DTOs.Group;

namespace Services.Validations.Group
{
    public class CreateDtoValidator:AbstractValidator<GroupCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(p => p.TimeId).NotNull().NotEmpty();
            RuleFor(p => p.Weekday).NotNull().NotEmpty();
            RuleFor(p => p.EducationId).NotNull().NotEmpty();
            RuleFor(p => p.RoomId).NotNull().NotEmpty();
        }
    }
}
