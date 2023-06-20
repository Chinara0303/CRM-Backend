using FluentValidation;
using Services.DTOs.Social;
using Services.DTOs.TecherSocial;

namespace Services.Validations.StaffSocial
{
    public class CreateDtoValidator:AbstractValidator<StaffSocialCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(s => s.Link).NotNull().NotEmpty();
            RuleFor(s => s.Name).NotNull().NotEmpty();
            RuleFor(s => s.StaffId).NotNull().NotEmpty();
        }
    }
}
