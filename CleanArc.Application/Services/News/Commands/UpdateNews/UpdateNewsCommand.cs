using Application.Common;
using CleanArc.Application.Services.News.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.News.Commands.UpdateNews
{
    public class UpdateNewsCommand : IRequest<ResponseModel<Guid>>
    {
        public UpdateNewsViewModel Model { get; set; }
    }
}
