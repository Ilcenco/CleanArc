using Application.Common.Interfaces;
using CleanArc.Application.Services.News.ViewModels;
using CleanArc.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.News.Queries.GetDataTable
{
    public class GetGridQueryHandler : IRequestHandler<GetGridQuery, IEnumerable<UpdateNewsViewModel>>
    {
        private readonly IDataContext _dataContext;
        public GetGridQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<UpdateNewsViewModel>> Handle(GetGridQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<UpdateNewsViewModel> news = await _dataContext.News.Select(s => new UpdateNewsViewModel()
            {
                Id = s.Id,
                Title = s.Title,
                Information = s.Information,
                IsPrivate =s.IsPrivate,
            })
            .Search(request.Model)
            .OrderBy(request.Model)
            .Page(request.Model)
            .ToListAsync(cancellationToken);
            return news;
        }
    }
}
