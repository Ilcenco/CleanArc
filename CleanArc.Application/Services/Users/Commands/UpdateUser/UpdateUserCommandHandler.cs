using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseModel<Guid>>
    {
        private readonly IDataContext _dataContext;
        private readonly UserManager<IdentityUser> _userManager;
        public UpdateUserCommandHandler(IDataContext dataContext, UserManager<IdentityUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }
        public async Task<ResponseModel<Guid>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
           
            string idStr = request.Model.Id.ToString();
            var user = await _dataContext.IdentityUsers.FirstOrDefaultAsync(u => u.Id == idStr);


            if (request.Model.ResetPassword)
            {
                
                _dataContext.IdentityUsers.Remove(user);
                await _dataContext.SaveChangesAsync(cancellationToken);

                user = new IdentityUser
                {
                    UserName = request.Model.Email,
                    Email = request.Model.Email,
                    PhoneNumber = request.Model.PhoneNumber,
                    EmailConfirmed = request.Model.IsActive,
                };
                user.Id = request.Model.Id.ToString();
                var result = await _userManager.CreateAsync(user, request.Model.Password);

                var userUpdateName = _dataContext.IdentityUsers.Where(u => u.Id.Equals(user.Id)).FirstOrDefault();
                userUpdateName.UserName = request.Model.UserName;
                _dataContext.IdentityUsers.Update(userUpdateName);
                await _dataContext.SaveChangesAsync(cancellationToken);
            }
            else
            {

                user.PhoneNumber = request.Model.PhoneNumber;
                user.UserName = request.Model.UserName;
                user.NormalizedUserName = request.Model.UserName.ToUpper();
                user.EmailConfirmed = request.Model.IsActive;
                _dataContext.IdentityUsers.Update(user);
                await _dataContext.SaveChangesAsync(cancellationToken);
            }
            

            var responseModel = new ResponseModel<Guid>
            {
                ResponseValue = Guid.Parse(user.Id),
                IsError = false,
                ErrorMessage = "",
            };
            return responseModel;
        }

    }

}
