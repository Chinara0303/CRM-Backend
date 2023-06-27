using FluentValidation;
using Services.DTOs.Slider;

namespace Services.Validations.Slider
{
    public class UpdateDtoValidator:AbstractValidator<SliderUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(s => s.Title).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(s => s.Description).NotNull().NotEmpty().MaximumLength(500);
        }
    }
}
