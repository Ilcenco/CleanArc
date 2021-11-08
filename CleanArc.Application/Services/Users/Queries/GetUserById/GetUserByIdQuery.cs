using Application.Common;
using Application.Users.ViewModels;
using MediatR;
using System;

namespace Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<ResponseModel<UserDetailViewModel>>
    {
        public Guid Id { get; set; }
    }
}
