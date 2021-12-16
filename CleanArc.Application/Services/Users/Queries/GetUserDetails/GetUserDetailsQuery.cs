using Application.Common;
using CleanArc.Application.Services.Users.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<ResponseModel<UserDetailViewModel>>
    {
        public Guid Id { get; set; }
    }
}
