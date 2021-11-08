using System;

namespace Application.Projects.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Guid CedacriInternationalRUser { get; set; }
        public string CedacriInternationalUserName { get; set; }
        public Guid CedacriItalyRUser { get; set; }
        public string CedacriItalyUserName { get; set; }
    }
}
