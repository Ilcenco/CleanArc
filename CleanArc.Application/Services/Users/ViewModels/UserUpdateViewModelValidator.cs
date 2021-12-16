using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArc.Application.Services.Users.ViewModels
{
    public class UserUpdateViewModelValidator : AbstractValidator<UserUpdateViewModel>
    {
        public UserUpdateViewModelValidator()
        {
            RuleFor(v => v.Id)
                .NotNull().WithMessage("Cant find user id");
            RuleFor(v => v.PhoneNumber)
                .NotNull().WithMessage("Phonenumber is required")
                .Length(9).WithMessage("Phonenumber should be of length 9");
            RuleFor(v => v.UserName)
                .NotNull().WithMessage("UserName is required");

        }
    }
}
