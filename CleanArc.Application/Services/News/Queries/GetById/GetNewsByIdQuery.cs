using Application.Common;
using CleanArc.Application.Services.News.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.News.Queries.GetById
{
    public class GetNewsByIdQuery : IRequest<ResponseModel<UpdateNewsViewModel>>
    {
        public Guid Id { get; set; }
    }
}
