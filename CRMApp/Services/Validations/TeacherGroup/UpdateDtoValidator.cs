using FluentValidation;
using Services.DTOs.TeacherGroup;

namespace Services.Validations.TeacherGroup
{
    public class UpdateDtoValidator:AbstractValidator<TeacherGroupUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(t => t.GroupId).NotNull().NotEmpty();
            RuleFor(t => t.TeacherIds).NotNull().NotEmpty();
        }
    }
}
