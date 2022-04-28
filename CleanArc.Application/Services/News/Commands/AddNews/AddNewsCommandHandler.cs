using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.News.Commands.AddNews
{
    class AddNewsCommandHandler : IRequestHandler<AddNewsCommand, ResponseModel<Guid>>
    {
        private readonly IDataContext _dataContext;
        public AddNewsCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<Guid>> Handle(AddNewsCommand request, CancellationToken cancellationToken)
        {
            var news = new Domain.Entities.News()
            {
                Id = Guid.NewGuid(),
                Title = request.Model.Title,
                Information = request.Model.Information,
                IsPrivate = request.Model.IsPrivate,
                Text = request.Model.Text,
                // ADD PRIVATE
            };
            await _dataContext.News.AddAsync(news);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return new ResponseModel<Guid>
            {
                IsError = false,
                ErrorMessage = string.Empty,
                ResponseValue = news.Id,
            };
        }
    }
}
