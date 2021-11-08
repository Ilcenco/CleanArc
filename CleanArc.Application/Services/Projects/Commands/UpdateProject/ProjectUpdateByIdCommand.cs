using Application.Common;
using CleanArc.Application.Services.Projects.Commands.ViewModels;
using MediatR;
using System;

namespace Application.Projects.Commands.UpdateProject
{
    public class ProjectUpdateByIdCommand : IRequest<ResponseModel<Guid>>
    {
        public ProjectUpdateViewModel Model { get; set; }
    }
}
