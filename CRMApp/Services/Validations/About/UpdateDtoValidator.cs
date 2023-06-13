using FluentValidation;
using Services.DTOs.About;

namespace Services.Validations.About
{
    public class UpdateDtoValidator:AbstractValidator<AboutUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(a => a.Title).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(a => a.SubTitle).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(a => a.Description).NotNull().NotEmpty();
        }
    }
}
