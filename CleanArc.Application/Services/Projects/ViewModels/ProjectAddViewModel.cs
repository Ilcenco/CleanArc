using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace CleanArc.Application.Services.Projects.ViewModels
{
    public class ProjectAddViewModel : IRequest
    {
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid CedacriInternationalRUser { get; set; }
        public Guid CedacriItalyRUser { get; set; }
        public List<ProjectRepositoryURLViewModel> URLs { get; set; }
    }
}
