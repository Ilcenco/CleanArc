﻿using System;

namespace Application.Users.ViewModels
{
    class UserDetailViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
