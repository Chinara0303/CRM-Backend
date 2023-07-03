using FluentValidation;
using Services.DTOs.Contact;


namespace Services.Validations.Contact
{
    public class CreateDtoValidator:AbstractValidator<ContactCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(c => c.Email).NotEmpty().NotNull().Must(c => c.Contains('@'));

        }
    }
}
