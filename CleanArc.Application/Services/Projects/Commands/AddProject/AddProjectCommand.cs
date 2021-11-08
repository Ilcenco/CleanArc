using Application.Common;
using CleanArc.Application.Services.Projects.ViewModels;
using MediatR;
using System;


namespace Application.Projects.Commands.AddProject
{
    public class AddProjectCommand : IRequest<ResponseModel<Guid>>
    {
        public ProjectAddViewModel projectAdd { get; set; }
    }
}
