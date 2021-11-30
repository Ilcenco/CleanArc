﻿using CleanArc.Application.Services.Projects.Commands.ViewModels;
using CleanArc.Application.Services.Projects.ViewModels;
using FluentValidation;

namespace CleanArc.Application.Services.Projects.Commands.UpdateProject
{
    public class ProjectUpdateViewModelValidator : AbstractValidator<ProjectUpdateViewModel>
    {
        public ProjectUpdateViewModelValidator()
        {
            RuleFor(v => v.Id).NotNull().WithMessage("Lol Id is null");
            RuleFor(v => v.CedacriInternationalRUser).NotNull().WithMessage(" Please provide something");
            RuleFor(v => v.CedacriItalyRUser).NotNull().WithMessage("it takes 2 clicks to choose one");
            RuleFor(v => v.DepartmentId).NotNull().WithMessage(" Choose department");
            RuleFor(v => v.Name).NotNull().WithMessage("u have a name, it should also have").NotEmpty().WithMessage("u have a name, it should also have");
            RuleForEach(v => v.URLs).SetValidator(new ProjectRepositoryURLViewModelValidator());
        }
    }
}
