using FluentValidation;
using Services.DTOs.TecherSocial;
namespace Services.Validations.TeacherSocial
{
    public class CreateDtoValidator:AbstractValidator<TeacherSocialCreateDto>
    {
        public CreateDtoValidator() 
        {
            RuleFor(s => s.Link).NotNull().NotEmpty();
            RuleFor(s => s.Name).NotNull().NotEmpty();
            RuleFor(s => s.TeacherId).NotNull().NotEmpty();
        }
    }
}
