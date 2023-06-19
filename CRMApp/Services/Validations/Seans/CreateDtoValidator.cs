using FluentValidation;
using Services.DTOs.Seans;

namespace Services.Validations.Seans
{
    public class CreateDtoValidator:AbstractValidator<SeansCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(s => s.Name).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
