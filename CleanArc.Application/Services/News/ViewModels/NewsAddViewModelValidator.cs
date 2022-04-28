using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.News.ViewModels
{
    public class NewsAddViewModelValidator : AbstractValidator<NewsAddViewModel>
    {
        public NewsAddViewModelValidator()
        {
            RuleFor(v => v.Title).NotNull().WithMessage("The title is required");
            RuleFor(v => v.Information).NotNull().WithMessage("Information is required");
            RuleFor(v => v.Text).NotNull().WithMessage("Text is required");
        }
        
    }
}
