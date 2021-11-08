using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Department : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Department() { Id = Guid.NewGuid(); }
    }
}
