using Application.Common;
using CleanArc.Application.Services.Users.ViewModels;
using MediatR;
using System;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<ResponseModel<Guid>>
    {
        public UserUpdateViewModel Model { get; set; }
    }
}
