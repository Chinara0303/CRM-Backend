using FluentValidation;
using Services.DTOs.Group;

namespace Services.Validations.Group
{
    public class UpdateDtoValidator:AbstractValidator<GroupUpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(p => p.RoomId).NotNull().NotEmpty();
        }
    }
}
