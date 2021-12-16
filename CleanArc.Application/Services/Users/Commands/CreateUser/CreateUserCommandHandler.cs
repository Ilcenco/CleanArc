using Application.Common;
using Application.Common.Interfaces;
using CleanArc.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace CleanArc.Application.Services.Users.Commands.CreateUser
{
    class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseModel<Guid>>
    {
        private readonly IDataContext _dataContext;
        private readonly UserManager<IdentityUser> _userManager;
        public CreateUserCommandHandler(IDataContext dataContext, UserManager<IdentityUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }
        public async Task<ResponseModel<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var user = new IdentityUser { 
                UserName = request.Model.Email,
                Email = request.Model.Email,
                PhoneNumber = request.Model.PhoneNumber,
                EmailConfirmed = request.Model.isActive,
            };
            var result = await _userManager.CreateAsync(user, "W3lcome."+ DateTime.Now.Year);

            var userUpdateName = _dataContext.IdentityUsers.Where(u => u.Id.Equals(user.Id)).FirstOrDefault();
            userUpdateName.UserName = request.Model.UserName;
            _dataContext.IdentityUsers.Update(userUpdateName);
            await _dataContext.SaveChangesAsync(cancellationToken);

            var responseModel = new ResponseModel<Guid>()
            {
                ErrorMessage = "",
                IsError = false,
                ResponseValue = Guid.Parse(user.Id)
            };

            return responseModel;
        }
    }
}
