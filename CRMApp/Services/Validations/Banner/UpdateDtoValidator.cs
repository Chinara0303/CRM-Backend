using FluentValidation;
using Services.DTOs.Banner;

namespace Services.Validations.Banner
{
    public class UpdateDtoValidator:AbstractValidator<BannerUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(b => b.Title).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(b => b.Description).NotNull().NotEmpty().MaximumLength(500);
            RuleFor(b => b.Offer).NotNull().NotEmpty();
        }
    }
}
