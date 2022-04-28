using Application.Common;
using CleanArc.Application.Services.News.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.News.Commands.AddNews
{
    public class AddNewsCommand : IRequest<ResponseModel<Guid>>
    {
        public NewsAddViewModel Model { get; set; }

    }
}
