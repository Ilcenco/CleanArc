using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.Users.Queries.GetEmailUnique
{
    public class GetEmailUniqueQueryHandler : IRequestHandler<GetEmailUniqueQuery, bool>
    {
        private readonly IDataContext _dataContext;
        public GetEmailUniqueQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> Handle(GetEmailUniqueQuery request, CancellationToken cancellationToken)
        {
            var emails = await _dataContext.IdentityUsers.Select(u => u.Email).ToListAsync();
            bool isUnique = emails.Any(x => x.Contains(request.Email));
            return isUnique;
        }
    }
}
