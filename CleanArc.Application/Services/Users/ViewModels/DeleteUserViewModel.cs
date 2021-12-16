using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Users.ViewModels
{
    public class DeleteUserViewModel: IRequest
    {
        public Guid Id { get; set; }
    }
}
