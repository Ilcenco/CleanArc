using CleanArc.Application.Services.Projects.ViewModels;
using FluentValidation;

namespace CleanArc.Application.Services.Projects.Commands.AddProject
{
    public class ProjectAddViewModelValidator : AbstractValidator<ProjectAddViewModel>
    {
        public ProjectAddViewModelValidator()
        {
            RuleFor(v => v.Name).NotNull().WithMessage("The name is required");
            RuleFor(v => v.DepartmentId).NotNull().WithMessage("Department is required");
            RuleFor(v => v.CedacriInternationalRUser).NotNull().WithMessage("Responsible user is required");
            RuleFor(v => v.CedacriItalyRUser).NotNull().WithMessage("Responsible user is required");
            RuleForEach(v => v.URLs).SetValidator(new ProjectRepositoryURLViewModelValidator());
        }
    }
}
