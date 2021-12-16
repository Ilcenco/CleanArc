using CleanArc.Application.Services.Projects.Commands.ViewModels;
using CleanArc.Application.Services.Projects.ViewModels;
using FluentValidation;

namespace CleanArc.Application.Services.Projects.Commands.UpdateProject
{
    public class ProjectUpdateViewModelValidator : AbstractValidator<ProjectUpdateViewModel>
    {
        public ProjectUpdateViewModelValidator()
        {
            RuleFor(v => v.Id).NotNull().WithMessage("Project Id cant be null");
            RuleFor(v => v.CedacriInternationalRUser).NotNull().WithMessage("Responsible user is required");
            RuleFor(v => v.CedacriItalyRUser).NotNull().WithMessage("Responsible user is required");
            RuleFor(v => v.DepartmentId).NotNull().WithMessage("Department is required");
            RuleFor(v => v.Name).NotNull().WithMessage("Name is required").NotEmpty().WithMessage("Name field is required");
            RuleForEach(v => v.URLs).SetValidator(new ProjectRepositoryURLViewModelValidator());
        }
    }
}
