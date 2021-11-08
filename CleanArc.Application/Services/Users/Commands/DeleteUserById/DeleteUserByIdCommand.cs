using Application.Common;
using MediatR;
using System;

namespace Application.Users.Commands.DeleteUserById
{
    public class DeleteUserByIdCommand : IRequest<ResponseModel<Guid>>
    {
        public Guid Id { get; set; }
    }
}
