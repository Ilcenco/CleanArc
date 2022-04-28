using Application.Common;
using Application.Common.Interfaces;
using CleanArc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.UserRoles.Commands
{
    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand, ResponseModel<Guid>>
    {
        private readonly IDataContext _dataContext;
        public AddUserRoleCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<Guid>> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            var userRole = new UserRole()
            {
                Role = request.Role,
            };
            _dataContext.UserRoles.Add(userRole);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return new ResponseModel<Guid>
            {
                IsError = false,
                ErrorMessage = null,
                ResponseValue = userRole.Id
            };
        }
    }
}
