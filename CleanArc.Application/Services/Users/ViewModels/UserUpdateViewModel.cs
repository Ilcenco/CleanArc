using MediatR;
using System;

namespace CleanArc.Application.Services.Users.ViewModels
{
    public class UserUpdateViewModel : IRequest
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool ResetPassword { get; set; }
    }
}
