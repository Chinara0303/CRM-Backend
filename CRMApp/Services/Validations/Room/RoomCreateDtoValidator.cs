using FluentValidation;
using Services.DTOs.Room;

namespace Services.Validations.Room
{
    public class RoomCreateDtoValidator:AbstractValidator<RoomCreateDto>
    {
        public RoomCreateDtoValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty().MaximumLength(50);
        }
    }
}
