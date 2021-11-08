using FluentValidation;

namespace Application.Projects.Queries.GetProjectPage
{
    class GetProjectPageQueryValidator : AbstractValidator<GetProjectPageQuery>
    {
        public GetProjectPageQueryValidator()
        {
            RuleFor(v => v.PageIndex).NotEmpty();
            RuleFor(v => v.PageSize).NotEmpty();
        }
    }
}
