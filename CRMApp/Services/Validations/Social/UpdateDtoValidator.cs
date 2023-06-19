using FluentValidation;
using Services.DTOs.Social;

namespace Services.Validations.Social
{
    public class UpdateDtoValidator:AbstractValidator<SocialUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(s => s.Link).NotNull().NotEmpty();
            RuleFor(s => s.Name).NotNull().NotEmpty();
            RuleFor(s => s.TeacherId).NotNull().NotEmpty();
        }
    }
}
