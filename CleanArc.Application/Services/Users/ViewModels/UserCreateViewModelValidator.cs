using FluentValidation;
namespace CleanArc.Application.Services.Users.ViewModels
{
    public class UserCreateViewModelValidator : AbstractValidator<UserCreateViewModel>
    {
        public UserCreateViewModelValidator()
        {
            RuleFor(v => v.Email)
                .EmailAddress().WithMessage("Write a valid email adress")
                .NotNull().WithMessage("Email field is required");
            RuleFor(v => v.PhoneNumber)
                .NotNull().WithMessage("Phonenumber is required")
                .Length(9).WithMessage("It should have 9 digits");
            RuleFor(v => v.UserName)
                .NotNull().WithMessage("Username field is required")
                .MinimumLength(2).WithMessage("Name should be longer than 2 chars")
                .MaximumLength(22).WithMessage("Name should not be longer than 22 chars");
                

        }
    }
}
