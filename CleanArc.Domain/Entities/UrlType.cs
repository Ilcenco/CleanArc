using Domain.Common;
using System;

namespace Domain.Entities
{
    public class UrlType : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public UrlType() { Id = Guid.NewGuid(); }
    }
}
