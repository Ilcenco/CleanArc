using Application.Common;
using CleanArc.Application.Services.Users.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<ResponseModel<Guid>>
    {
        public UserCreateViewModel Model { get; set; }
    }
}
