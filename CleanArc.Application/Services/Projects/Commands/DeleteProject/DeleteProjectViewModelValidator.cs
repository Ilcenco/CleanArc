using CleanArc.Application.Services.Projects.Commands.ViewModels;
using FluentValidation;

namespace CleanArc.Application.Services.Projects.Commands.DeleteProject
{
    class DeleteProjectViewModelValidator : AbstractValidator<ProjectDeleteViewModel>
    {
        public DeleteProjectViewModelValidator()
        {
            RuleFor(v => v.Id).NotNull().WithMessage("Provide an Id");
        }
    }
}
