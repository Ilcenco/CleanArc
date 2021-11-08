using Application.Common;
using Application.Common.Interfaces;
using Application.Users.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserById
{
    class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResponseModel<UserDetailViewModel>>
    {
        private readonly IDataContext _dataContext;
        public GetUserByIdQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<UserDetailViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var rM = new ResponseModel<UserDetailViewModel>();
            if (_dataContext.IdentityUsers.Any())
            {

                rM.ErrorMessage = "";
                rM.IsError = false;
                rM.ResponseValue = await _dataContext.IdentityUsers
                    .Where(u => u.Id == request.Id.ToString())
                    .Select(s => new UserDetailViewModel()
                {
                    Id = Guid.Parse(s.Id),
                    UserName = s.UserName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber

                }).SingleOrDefaultAsync(cancellationToken);
            }
            else
            {
                rM.ErrorMessage = "No Users Found";
                rM.IsError = true;
                rM.ResponseValue = null;
            }

            return rM;
        }
    }
}
