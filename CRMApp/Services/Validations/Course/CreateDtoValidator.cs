using FluentValidation;
using Services.DTOs.Course;

namespace Services.Validations.Course
{
    public class CreateDtoValidator : AbstractValidator<CourseCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(a => a.Name).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(a => a.Price).GreaterThan(1000);
            RuleFor(a => a.Description).NotNull().NotEmpty();
            RuleFor(a => a.Photo).NotNull().NotEmpty();
        }
    }
}
