﻿using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseModel<Guid>>
    {
        private readonly IDataContext _dataContext;
        private readonly UserManager<IdentityUser> _userManager;
        public UpdateUserCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<Guid>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
           
            string idStr = request.Model.Id.ToString();
            var user = await _dataContext.IdentityUsers
                .FirstOrDefaultAsync(u => u.Id == idStr);

            user.PhoneNumber = request.Model.PhoneNumber;
            user.UserName = request.Model.UserName;
            user.NormalizedUserName = request.Model.UserName.ToUpper();
            user.Email = request.Model.Email;
            user.NormalizedEmail = request.Model.Email.ToUpper();

            _dataContext.IdentityUsers.Update(user);


            await _dataContext.SaveChangesAsync(cancellationToken);
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
