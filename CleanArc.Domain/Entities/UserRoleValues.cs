using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Domain.Entities
{
    public class UserRoleValues: AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserRole { get; set; }
        public Guid UserId { get; set; }
    }
}
