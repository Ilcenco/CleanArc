using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Users.Queries.GetUserProjectsList
{
    public class GetUserProjectsNumberQuery: IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
