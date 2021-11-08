using Application.Common;
using CleanArc.Application.Services.Projects.Commands.ViewModels;
using MediatR;
using System;

namespace CleanArc.Application.Services.Projects.Queries.GetProjectVmById
{
    public class GetProjectVmByIdQuery : IRequest<ResponseModel<ProjectUpdateViewModel>>
    {
        public Guid Id { get; set; }
    }
}
