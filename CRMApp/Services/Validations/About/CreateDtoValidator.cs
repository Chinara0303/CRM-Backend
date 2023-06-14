using FluentValidation;
using Services.DTOs.About;

namespace Services.Validations.About
{
    public class CreateDtoValidator:AbstractValidator<AboutCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(a => a.Title).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(a => a.SubTitle).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(a => a.Description).NotNull().NotEmpty();
            RuleFor(a => a.Photo).NotNull().NotEmpty();
        }
    }
}
