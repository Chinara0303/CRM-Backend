using FluentValidation;
using Services.DTOs.Seans;

namespace Services.Validations.Seans
{
    public class UpdateDtoValidator:AbstractValidator<SeansUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(s => s.Name).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
