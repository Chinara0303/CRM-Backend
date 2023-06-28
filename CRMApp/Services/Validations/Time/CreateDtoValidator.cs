using FluentValidation;
using Services.DTOs.Time;

namespace Services.Validations.Time
{
    public class CreateDtoValidator : AbstractValidator<TimeCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(t => t.Start).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(t => t.End).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
