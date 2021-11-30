using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Projects.ViewModels
{
    public class ProjectRepositoryURLViewModelValidator : AbstractValidator<ProjectRepositoryURLViewModel>
    {
        public ProjectRepositoryURLViewModelValidator()
        {
            //RuleFor(v => v.Url).NotNull().WithMessage("Insert Url adress");
            //RuleFor(v => v.UrlTypeId).NotNull().WithMessage("Url type also required").NotEmpty().WithMessage("Select url type");
        }
    }
}
