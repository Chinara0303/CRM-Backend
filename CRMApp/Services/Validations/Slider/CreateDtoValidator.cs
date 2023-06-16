using FluentValidation;
using Services.DTOs.Slider;

namespace Services.Validations.Slider
{
    public class CreateDtoValidator:AbstractValidator<SliderCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(s => s.Title).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(s => s.Description).NotNull().NotEmpty().MaximumLength(500);
            RuleFor(s => s.Photo).NotNull().NotEmpty();
        }
    }
}
