using CleanArc.Application.Services.Users.ViewModels;
using FluentValidation;

namespace CleanArc.Application.Services.Users.Commands.UpdateUser
{
    class UpdateUserViewModelValidator : AbstractValidator<UserUpdateViewModel>
    {
        public UpdateUserViewModelValidator()
        {
            RuleFor(v => v.Id).NotNull();
            RuleFor(v => v.Email).EmailAddress();
            RuleFor(v => v.PhoneNumber).NotEmpty().MaximumLength(9).MinimumLength(9);
            RuleFor(v => v.UserName).NotNull();
        }
    }
}
