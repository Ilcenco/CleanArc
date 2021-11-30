using Application.Common;
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
            if (request.Model.ResetPassword)
            {
                user.PasswordHash = HashPassword("Cedacri1.");
                user.SecurityStamp = Guid.NewGuid().ToString();
            }


            await _dataContext.SaveChangesAsync(cancellationToken);
            var responseModel = new ResponseModel<Guid>
            {
                ResponseValue = Guid.Parse(user.Id),
                IsError = false,
                ErrorMessage = "",
            };
            return responseModel;
        }
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] bytes;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes rfc2898DeriveByte = new Rfc2898DeriveBytes(password, 16, 1000))
            {
                salt = rfc2898DeriveByte.Salt;
                bytes = rfc2898DeriveByte.GetBytes(32);
            }
            byte[] numArray = new byte[49];
            Buffer.BlockCopy(salt, 0, numArray, 1, 16);
            Buffer.BlockCopy(bytes, 0, numArray, 17, 32);
            return Convert.ToBase64String(numArray);
        }

    }

}
