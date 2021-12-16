using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Users.Queries.GetEmailUnique
{
    public class GetEmailUniqueQuery: IRequest<bool>
    {
        public string Email { get; set; }
    }
}
