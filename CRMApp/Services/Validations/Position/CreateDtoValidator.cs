using FluentValidation;
using Services.DTOs.Position;


namespace Services.Validations.Position
{
    public class CreateDtoValidator:AbstractValidator<PositionCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
