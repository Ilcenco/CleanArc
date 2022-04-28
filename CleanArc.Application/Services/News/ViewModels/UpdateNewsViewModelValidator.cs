using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.News.ViewModels
{
    public class UpdateNewsViewModelValidator : AbstractValidator<UpdateNewsViewModel>
    {
        public UpdateNewsViewModelValidator()
        {
            RuleFor(v => v.Id).NotNull().WithMessage("Project Id cant be null");
            RuleFor(v => v.Title).NotNull().WithMessage("Title is required");
            RuleFor(v => v.Information).NotNull().WithMessage("Information is required");
            RuleFor(v => v.Text).NotNull().WithMessage("Text is required");
        }
    }
}
