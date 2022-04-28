using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.UserRoles.Commands
{
    public class AddUserRoleCommand : IRequest<ResponseModel<Guid>>
    {
        public string Role { get; set; }
    }
}
