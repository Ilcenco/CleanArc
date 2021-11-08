using FluentValidation;


namespace Application.Departments.Queries.GetDepartmentById
{
    class GetDepartmentByIdQueryValidator : AbstractValidator<GetDepartmentByIdQuery>
    {
        public GetDepartmentByIdQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
