using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Users.ViewModels
{
    public class UserCreateViewModel : IRequest
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public bool isActive { get; set; }
        
    }
}
