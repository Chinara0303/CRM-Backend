using FluentValidation;
using Services.DTOs.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
