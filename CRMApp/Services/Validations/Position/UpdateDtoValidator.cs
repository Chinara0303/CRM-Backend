using FluentValidation;
using Services.DTOs.Position;

namespace Services.Validations.Position
{
    public class UpdateDtoValidator:AbstractValidator<PositionUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
