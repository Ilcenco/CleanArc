using System;

namespace CleanArc.Application.Services.Users.ViewModels
{
    public class UserDetailViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool  IsActive { get; set; }
        public bool  ResetPassword { get; set; }
    }
}
