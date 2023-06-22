using FluentValidation;
using Services.DTOs.TeacherGroup;

namespace Services.Validations.TeacherGroup
{
    public class CreateDtoValidator:AbstractValidator<TeacherGroupCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(t => t.GroupId).NotNull().NotEmpty();
            RuleFor(t => t.TeacherIds).NotNull().NotEmpty();
        }
    }
}
