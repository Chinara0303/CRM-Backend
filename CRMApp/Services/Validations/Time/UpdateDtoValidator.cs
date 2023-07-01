using FluentValidation;
using Services.DTOs.Time;

namespace Services.Validations.Time
{
    public class UpdateDtoValidator : AbstractValidator<TimeUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(t => t.Start).NotNull().NotEmpty();
            RuleFor(t => t.End).NotNull().NotEmpty();
        }
    }
}
