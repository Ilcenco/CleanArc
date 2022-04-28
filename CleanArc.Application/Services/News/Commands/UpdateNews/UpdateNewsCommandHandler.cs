using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.News.Commands.UpdateNews
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, ResponseModel<Guid>>
    {
        private readonly IDataContext _dataContext;
        public UpdateNewsCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<Guid>> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _dataContext.News.Where(x => x.Id.Equals(request.Model.Id)).FirstOrDefaultAsync(cancellationToken);
            news.Information = request.Model.Information;
            news.Title = request.Model.Title;
            news.IsPrivate = request.Model.IsPrivate;
            news.Text = request.Model.Text;
            _dataContext.News.Update(news);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return new ResponseModel<Guid>
            {
                ErrorMessage = "",
                IsError = false,
                ResponseValue = news.Id
            };
        }
    }
}
