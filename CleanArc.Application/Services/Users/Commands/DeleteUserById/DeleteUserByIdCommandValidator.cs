using FluentValidation;

namespace Application.Users.Commands.DeleteUserById
{
    class DeleteUserByIdCommandValidator : AbstractValidator<DeleteUserByIdCommand>
    {
        public DeleteUserByIdCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
