using FluentValidation;
using Services.DTOs.Subscribe;

namespace Services.Validations.Subscribe
{
    public class CreateDtoValidator : AbstractValidator<SubscribeCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(c => c.Email).NotEmpty().NotNull().Must(c => c.Contains('@'));
        }
    }
}
