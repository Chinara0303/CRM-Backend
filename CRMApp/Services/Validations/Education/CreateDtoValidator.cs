using FluentValidation;
using Services.DTOs.Education;

namespace Services.Validations.Education
{
    public class CreateDtoValidator : AbstractValidator<EducationCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(a => a.Name).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(a => a.Price).GreaterThan(1000).WithMessage("1000den yuxari olmaldir");
            RuleFor(a => a.Description).NotNull().NotEmpty();
            RuleFor(a => a.Photo).NotNull().NotEmpty();
        }
    }
}
