using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Users.ViewModels
{
    public class DeleteUserViewModelValidator: AbstractValidator<DeleteUserViewModel>
    {
        public DeleteUserViewModelValidator()
        {
            RuleFor(u => u.Id)
                .NotNull().WithMessage("User can't be null");
        }
    }
}
