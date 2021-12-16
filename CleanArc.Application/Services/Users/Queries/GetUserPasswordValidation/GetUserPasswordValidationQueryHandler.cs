using CleanArc.Application.Services.Users.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.Users.Queries.GetUserPasswordValidation
{
    public class GetUserPasswordValidationQueryHandler : IRequestHandler<GetUserPasswordValidationQuery, PasswordEditValidateViewModel>
    {
        public async Task<PasswordEditValidateViewModel> Handle(GetUserPasswordValidationQuery request, CancellationToken cancellationToken)
        {
            var response = new PasswordEditValidateViewModel();
            if (request.Password == null)
            {
                response.isValid = false;
                response.Message = "Password is required";
            }
            else if (request.Password.Length < 9)
            {
                response.isValid = false;
                response.Message = "Password is shorter than 9";
            }
            else if (request.Password.Any(char.IsUpper) && request.Password.Any(char.IsLower))
            {
                response.isValid = false;
                response.Message = "Password must contain at least 1 uppercase and 1 lowecase letter";
            }
            else
            {
                response.isValid = true;
                response.Message = "";
            }
            return response;
        }
    }
}
