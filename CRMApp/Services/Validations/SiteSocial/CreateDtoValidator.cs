using FluentValidation;
using Services.DTOs.SiteSocial;

namespace Services.Validations.SiteSocial
{
    public class CreateDtoValidator:AbstractValidator<SiteSocialCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(s => s.Link).NotNull().NotEmpty();
            RuleFor(s => s.Name).NotNull().NotEmpty();
            RuleFor(s => s.IconName).NotNull().NotEmpty();
        }
    }
}
