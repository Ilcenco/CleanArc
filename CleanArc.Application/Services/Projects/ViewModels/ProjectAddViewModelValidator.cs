using CleanArc.Application.Services.Projects.ViewModels;
using FluentValidation;

namespace CleanArc.Application.Services.Projects.Commands.AddProject
{
    public class ProjectAddViewModelValidator : AbstractValidator<ProjectAddViewModel>
    {
        public ProjectAddViewModelValidator()
        {
            RuleFor(v => v.Name).NotNull().WithMessage("The name is required");
            RuleFor(v => v.DepartmentId).NotNull().WithMessage("Max said it is also required");
            RuleFor(v => v.CedacriInternationalRUser).NotNull().WithMessage("This too");
            RuleFor(v => v.CedacriItalyRUser).NotNull().WithMessage("Man, everithing is required");
        }
    }
}
