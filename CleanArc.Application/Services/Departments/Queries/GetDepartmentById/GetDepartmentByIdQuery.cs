using System;
using Application.Common;
using Application.Departments.ViewModels;
using MediatR;

namespace Application.Departments.Queries
{
    public class GetDepartmentByIdQuery : IRequest<ResponseModel<DepartmentDetailsViewModel>>
    {
        public Guid Id { get; set; }
    }
}
