using FluentValidation;
using Services.DTOs.Setting;

namespace Services.Validations.Setting
{
    public class UpdateDtoValidator:AbstractValidator<SettingUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(s => s.Value).NotEmpty().NotNull();
        }
    }
}
