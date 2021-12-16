using CleanArc.Application.Services.Users.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Users.Queries.GetUserPasswordValidation
{
    public class GetUserPasswordValidationQuery :IRequest<PasswordEditValidateViewModel>
    {
        public string Password { get; set; }
    }
}
