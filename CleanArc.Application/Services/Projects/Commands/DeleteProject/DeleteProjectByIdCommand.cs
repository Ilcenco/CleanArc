using Application.Common;
using CleanArc.Application.Services.Projects.Commands.ViewModels;
using MediatR;
using System;

namespace Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectByIdCommand : IRequest<ResponseModel<Guid>>
    {
        public ProjectDeleteViewModel Model { get; set; }
    }
}
