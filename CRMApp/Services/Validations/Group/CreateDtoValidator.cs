
using FluentValidation;
using Services.DTOs.Group;

namespace Services.Validations.Group
{
    public class CreateDtoValidator:AbstractValidator<GroupCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(p => p.Seans).NotNull().NotEmpty();
            RuleFor(p => p.Weekday).NotNull().NotEmpty();
            RuleFor(p => p.CourseId).NotNull().NotEmpty();
            RuleFor(p => p.RoomId).NotNull().NotEmpty();
        }
    }
}
