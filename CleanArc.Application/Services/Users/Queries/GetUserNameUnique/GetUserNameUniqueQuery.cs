using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Users.Queries.GetUserNameUnique
{
    public class GetUserNameUniqueQuery: IRequest<bool>
    {
        public Guid? Id { get; set; }
        public string UserName { get; set; }
    }
}
