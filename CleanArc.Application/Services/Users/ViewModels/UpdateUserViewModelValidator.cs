using CleanArc.Application.Services.Users.ViewModels;
using FluentValidation;

namespace CleanArc.Application.Services.Users.Commands.UpdateUser
{
    class UpdateUserViewModelValidator : AbstractValidator<UserUpdateViewModel>
    {
        public UpdateUserViewModelValidator()
        {
            RuleFor(v => v.Id)
                .NotNull().WithMessage("Lol, gi-mme Id");
            RuleFor(v => v.Email)
                .EmailAddress().WithMessage("Am i a joke to you ?")
                .NotNull().WithMessage("write something here");
            RuleFor(v => v.PhoneNumber)
                .NotNull().WithMessage("How will you call him dude ?")
                .MaximumLength(9).WithMessage("Yes, infinite length, max9")
                .MinimumLength(9).WithMessage("yes, just type 112, min9")
                .NotNull().WithMessage("write something here");
            RuleFor(v => v.UserName)
                .NotNull().WithMessage("write something here");
            
        }
    }
}
