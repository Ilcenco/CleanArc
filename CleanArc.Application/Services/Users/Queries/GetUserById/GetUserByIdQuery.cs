using Application.Common;
using CleanArc.Application.Services.Users.ViewModels;
using MediatR;
using System;

namespace Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<ResponseModel<UserUpdateViewModel>>
    {
        public Guid Id { get; set; }
    }
}
