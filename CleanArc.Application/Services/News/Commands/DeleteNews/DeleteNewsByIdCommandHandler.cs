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

namespace CleanArc.Application.Services.News.Commands.DeleteNews
{
    public class DeleteNewsByIdCommandHandler : IRequestHandler<DeleteNewsByIdCommand, ResponseModel<Guid>>
    {
        private readonly IDataContext _dataContext;
        public DeleteNewsByIdCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<Guid>> Handle(DeleteNewsByIdCommand request, CancellationToken cancellationToken)
        {
            var model = await _dataContext.News.Where(x=> x.Id.Equals(request.Id)).FirstOrDefaultAsync(cancellationToken);
            _dataContext.News.Remove(model);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return new ResponseModel<Guid>
            {
                ErrorMessage = "",
                IsError = false,
                ResponseValue = model.Id
            };
        }
    }
}
