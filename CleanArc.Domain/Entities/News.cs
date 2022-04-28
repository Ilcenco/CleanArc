using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Domain.Entities
{
    public class News : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Information { get; set; }
        public bool IsPrivate { get; set; }
        public string Text { get; set; }
    }
}
