using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.DeleteUserById
{
    class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, ResponseModel<Guid>>
    {
        private readonly IDataContext _dataContext;
        public DeleteUserByIdCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<Guid>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _dataContext.IdentityUsers
                .FirstOrDefaultAsync(c => c.Id.Equals(request.Id.ToString()));
            if (user == null)
            {
                return new ResponseModel<Guid>
                {
                    ResponseValue = request.Id,
                    IsError = true,
                    ErrorMessage = "Not found by that Id"
                };
            }

            _dataContext.IdentityUsers.Remove(user);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return new ResponseModel<Guid>
            {
                ResponseValue = request.Id,
                IsError = false,
                ErrorMessage = "Deleted User"
            };
        }
    }
}
