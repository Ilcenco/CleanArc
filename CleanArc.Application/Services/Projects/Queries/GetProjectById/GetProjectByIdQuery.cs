using Application.Common;
using Application.Projects.ViewModels;
using MediatR;
using System;

namespace Application.Projects.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ResponseModel<ProjectDetailsViewModel>>
    {
        public Guid Id { get; set; }
        
    }
}
