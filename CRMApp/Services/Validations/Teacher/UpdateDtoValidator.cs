using FluentValidation;
using Services.DTOs.Teacher;

namespace Services.Validations.Teacher
{
    public class UpdateDtoValidator:AbstractValidator<TeacherUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(s => s.FullName).NotNull().NotEmpty();
            RuleFor(s => s.Address).NotNull().NotEmpty();
            RuleFor(s => s.Age).NotNull().NotEmpty();
            RuleFor(s => s.Biography).NotNull().NotEmpty();
            RuleFor(s => s.Email).NotNull().NotEmpty().Must(s => s.Contains('@'));
            RuleFor(s => s.Phone).NotNull().NotEmpty();
        }
    }
}
