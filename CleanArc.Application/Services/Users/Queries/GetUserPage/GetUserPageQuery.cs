using Application.Common;
using CleanArc.Application.Services.Users.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Application.Users.Queries.GetUserPage
{
    public class GetUserPageQuery : IRequest<ResponseModel<IList<UserDetailViewModel>>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string Filter { get; set; }
    }
}
