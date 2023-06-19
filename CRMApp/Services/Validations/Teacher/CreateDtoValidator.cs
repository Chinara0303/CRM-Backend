using FluentValidation;
using Services.DTOs.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validations.Teacher
{
    public class CreateDtoValidator:AbstractValidator<TeacherCreateDto>
    {
        public CreateDtoValidator()
        {
            RuleFor(s => s.FullName).NotNull().NotEmpty();
            RuleFor(s => s.Address).NotNull().NotEmpty();
            RuleFor(s => s.Age).NotNull().NotEmpty();
            RuleFor(s => s.Biography).NotNull().NotEmpty();
            RuleFor(s => s.Email).NotNull().NotEmpty().Must(s => s.Contains('@'));
            RuleFor(s => s.Phone).NotNull().NotEmpty();
            RuleFor(s => s.Photo).NotNull().NotEmpty();
        }
    }
}
