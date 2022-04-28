using Application.Common;
using Application.Common.Interfaces;
using CleanArc.Application.Services.News.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.News.Queries.GetById
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, ResponseModel<UpdateNewsViewModel>>
    {
        private readonly IDataContext _dataContext;
        public GetNewsByIdQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<UpdateNewsViewModel>> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _dataContext.News.Where(x => x.Id.Equals(request.Id)).FirstOrDefaultAsync(cancellationToken);

            var viewModel = new UpdateNewsViewModel()
            {
                Id = model.Id,
                Information = model.Information,
                IsPrivate = model.IsPrivate,
                Title = model.Title,
                Text = model.Text,
            };
            return new ResponseModel<UpdateNewsViewModel>()
            {
                ErrorMessage = "",
                IsError = false,
                ResponseValue = viewModel,
            };
        }
    }
}
