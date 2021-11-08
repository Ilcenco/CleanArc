using MediatR;
using System;

namespace CleanArc.Application.Services.Projects.ViewModels
{
    public class ProjectAddViewModel : IRequest
    {
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid CedacriInternationalRUser { get; set; }
        public Guid CedacriItalyRUser { get; set; }
    }
}
