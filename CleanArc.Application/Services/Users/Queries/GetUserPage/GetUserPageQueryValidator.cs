using FluentValidation;

namespace Application.Users.Queries.GetUserPage
{
    class GetUserPageQueryValidator : AbstractValidator<GetUserPageQuery>
    {
        public GetUserPageQueryValidator()
        {
            RuleFor(v => v.PageIndex).NotEmpty();
            RuleFor(v => v.PageSize).NotEmpty();
        }
    }
}
