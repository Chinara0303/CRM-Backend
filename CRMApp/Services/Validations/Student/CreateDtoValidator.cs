
using FluentValidation;
using Services.DTOs.Student;

namespace Services.Validations.Student
{
    public class CreateDtoValidator:AbstractValidator<StudentCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(s => s.FullName).NotNull().NotEmpty();
            RuleFor(s => s.Address).NotNull().NotEmpty();
            RuleFor(s => s.Age).NotNull().NotEmpty();
            RuleFor(s => s.Biography).NotNull().NotEmpty();
            RuleFor(s => s.Email).NotNull().NotEmpty().Must(s => s.Contains('@'));
            RuleFor(s => s.Phone).NotNull().NotEmpty();
            RuleFor(s => s.Photo).NotNull().NotEmpty();
        }
    }
}
