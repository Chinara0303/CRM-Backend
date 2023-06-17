using FluentValidation;
using Services.DTOs.Education;

namespace Services.Validations.Education
{
    public class UpdateDtoValidator : AbstractValidator<EductaionUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(a => a.Name).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(a => a.Price).GreaterThan(1000);
            RuleFor(a => a.Description).NotNull().NotEmpty();
            RuleFor(a => a.Photo).NotNull().NotEmpty();
        }
    }
}
