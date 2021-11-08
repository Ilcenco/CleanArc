using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Project : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid CedacriInternationalRUser { get; set; }
        public Guid CedacriItalyRUser { get; set; }

        public Project() { Id = Guid.NewGuid(); }
    }
}
