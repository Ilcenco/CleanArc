using Application.Common.Interfaces;
using CleanArc.Application.Services.Users.ViewModels;
using CleanArc.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.Users.Queries.GetUserDataTable
{
    public class GetUserDataTableQueryHandler : IRequestHandler<GetUserDataTableQuery, IEnumerable<UserDetailViewModel>>
    {
        private readonly IDataContext _dataContext;
        public GetUserDataTableQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<UserDetailViewModel>> Handle(GetUserDataTableQuery request, CancellationToken cancellationToken)
        {

            // Create Initial Project List to Work With
            IEnumerable<UserDetailViewModel> users = await _dataContext.IdentityUsers.Select(s => new UserDetailViewModel()
            {
                Id = s.Id,
                UserName = s.UserName,
                PhoneNumber = s.PhoneNumber,
                Email = s.Email,
                IsActive = s.EmailConfirmed
            })
            .Search(request.Model)
            .OrderBy(request.Model)
            .Page(request.Model)
            .ToListAsync(cancellationToken);
            return users;
        }
    }
}
