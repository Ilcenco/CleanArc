using CleanArc.Application.Services.Users.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Users.Queries.GetUserType
{
    public class GetUserTypeQuery : IRequest<string>
    {
        public string Name { get; set; }

    }
}
