using Application.Common;
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

namespace CleanArc.Application.Services.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, ResponseModel<UserDetailViewModel>>
    {
        private readonly IDataContext _dataContext;
        public GetUserDetailsQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<UserDetailViewModel>> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
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
                        Id = s.Id,
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
