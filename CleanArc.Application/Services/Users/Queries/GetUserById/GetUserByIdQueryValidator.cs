using FluentValidation;

namespace Application.Users.Queries.GetUserById
{
    class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(v => v.Id).NotNull();
        }
    }
}
