using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.Users.Queries.GetUserNameUnique
{
    public class GetUserNameUniqueQueryHandler : IRequestHandler<GetUserNameUniqueQuery, bool>
    {
        private readonly IDataContext _dataContext;
        public GetUserNameUniqueQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> Handle(GetUserNameUniqueQuery request, CancellationToken cancellationToken)
        {
            var users = await _dataContext.IdentityUsers.ToListAsync();
            if (request.Id == null)
            {
                return users.Any(x => x.UserName.ToLower().Contains(request.UserName.ToLower()));
            }
            else
            {
                foreach (var user in users)
                {
                    if (user.UserName.ToLower() == request.UserName.ToLower() && user.Id != request.Id.ToString())
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
