using FluentValidation;
using Services.DTOs.Room;

namespace Services.Validations.Room
{
    public class CreateDtoValidator:AbstractValidator<RoomCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty().MaximumLength(50);
        }
    }
}
