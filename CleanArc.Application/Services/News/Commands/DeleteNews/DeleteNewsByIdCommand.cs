using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.News.Commands.DeleteNews
{
    public class DeleteNewsByIdCommand : IRequest<ResponseModel<Guid>>
    {
        public Guid Id { get; set; }
    }
}
