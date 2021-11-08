using MediatR;
using System;

namespace CleanArc.Application.Services.Projects.Commands.ViewModels
{
    public class ProjectUpdateViewModel : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid CedacriInternationalRUser { get; set; }
        public Guid CedacriItalyRUser { get; set; }
    }
}
