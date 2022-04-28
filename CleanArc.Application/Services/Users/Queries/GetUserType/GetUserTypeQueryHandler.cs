using Application.Common.Interfaces;
using CleanArc.Application.Services.Users.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.Users.Queries.GetUserType
{
    public class GetUserTypeQueryHandler : IRequestHandler<GetUserTypeQuery, string>
    {
        private readonly IDataContext _dataContext;
        public GetUserTypeQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<string> Handle(GetUserTypeQuery request, CancellationToken cancellationToken)
        {
            var user = await _dataContext.IdentityUsers
                    .Where(u => u.NormalizedEmail.ToLower() == request.Name.ToLower())
                    .Select(s => new UserUpdateViewModel()
                    {
                        Id = Guid.Parse(s.Id),
                        UserName = s.UserName,
                        Email = s.Email,
                        PhoneNumber = s.PhoneNumber,
                        IsActive = s.EmailConfirmed,
                        ResetPassword = false,

                    }).SingleOrDefaultAsync(cancellationToken);
            var userRoleValueEntity = await _dataContext.UserRoleValues.Where(x => x.UserId.Equals(user.Id)).FirstOrDefaultAsync();
            var userRole = await _dataContext.UserRoles.FirstOrDefaultAsync(x => x.Id.Equals(userRoleValueEntity.UserRole));
            return userRole.Role;
        }
    }
}
