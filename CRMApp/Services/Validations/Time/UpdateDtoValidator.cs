using FluentValidation;
using Services.DTOs.Time;

namespace Services.Validations.Time
{
    public class UpdateDtoValidator : AbstractValidator<TimeUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(t => t.Interval).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
