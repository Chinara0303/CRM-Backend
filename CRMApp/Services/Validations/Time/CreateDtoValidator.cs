using FluentValidation;
using Services.DTOs.Time;

namespace Services.Validations.Time
{
    public class CreateDtoValidator : AbstractValidator<TimeCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(t => t.Interval).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
