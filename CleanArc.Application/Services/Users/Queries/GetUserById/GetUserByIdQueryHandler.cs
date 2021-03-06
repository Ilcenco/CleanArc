using Application.Common;
using Application.Common.Interfaces;
using CleanArc.Application.Services.Users.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserById
{
    class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResponseModel<UserUpdateViewModel>>
    {
        private readonly IDataContext _dataContext;
        public GetUserByIdQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<UserUpdateViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var rM = new ResponseModel<UserUpdateViewModel>();
            if (_dataContext.IdentityUsers.Any())
            {

                rM.ErrorMessage = "";
                rM.IsError = false;
                rM.ResponseValue = await _dataContext.IdentityUsers
                    .Where(u => u.Id == request.Id.ToString())
                    .Select(s => new UserUpdateViewModel()
                    {
                        Id = Guid.Parse(s.Id),
                        UserName = s.UserName,
                        Email = s.Email,
                        PhoneNumber = s.PhoneNumber,
                        IsActive = s.EmailConfirmed,
                        ResetPassword = false,

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
