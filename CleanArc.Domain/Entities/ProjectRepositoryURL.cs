using Domain.Common;
using System;

namespace Domain.Entities
{
    public class ProjectRepositoryURL : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UrlTypeId { get; set; }

        public ProjectRepositoryURL() { Id = Guid.NewGuid(); }
    }
}
