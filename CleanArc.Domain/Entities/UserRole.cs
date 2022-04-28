using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Domain.Entities
{
    public class UserRole : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Role { get; set; }

        public UserRole()
        {
            Id = Guid.NewGuid();
        }
    }
}
