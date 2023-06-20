using FluentValidation;
using Services.DTOs.Social;

namespace Services.Validations.StaffSocial
{
    public class UpdateDtoValidator : AbstractValidator<StaffSocialUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(s => s.Link).NotNull().NotEmpty();
            RuleFor(s => s.Name).NotNull().NotEmpty();
            RuleFor(s => s.StaffId).NotNull().NotEmpty();
        }
    }
}
