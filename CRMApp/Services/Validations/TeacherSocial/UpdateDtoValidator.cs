using FluentValidation;
using Services.DTOs.TecherSocial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validations.TeacherSocial
{
    public class UpdateDtoValidator:AbstractValidator<TeacherSocialUpdateDto>
    {
        public UpdateDtoValidator() 
        {
            RuleFor(s => s.Link).NotNull().NotEmpty();
            RuleFor(s => s.Name).NotNull().NotEmpty();
            RuleFor(s => s.TeacherId).NotNull().NotEmpty();
        }
    }
}
