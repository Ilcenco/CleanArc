using CleanArc.Application.Services.Users.ViewModels;
using FluentValidation;

namespace CleanArc.Application.Services.Users.Commands.UpdateUser
{
    class UpdateUserViewModelValidator : AbstractValidator<UserUpdateViewModel>
    {
        public UpdateUserViewModelValidator()
        {
            RuleFor(v => v.Password)
               .NotNull().WithMessage("Password field is required");
            RuleFor(v => v.Id)
                .NotNull().WithMessage("Cant edit user without Id");
            RuleFor(v => v.Email)
                .EmailAddress().WithMessage("Write a valid email")
                .NotNull().WithMessage("Email field is required");
            RuleFor(v => v.PhoneNumber)
                .NotNull().WithMessage("Phone field is required")
                .MaximumLength(9).WithMessage("Length should be 9")
                .MinimumLength(9).WithMessage("Length should be 9");           
            
        }
    }
}
