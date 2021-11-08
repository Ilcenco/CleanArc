using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects.Commands.DeleteProject
{
    class DeleteProjectByIdCommandHandler : IRequestHandler<DeleteProjectByIdCommand, ResponseModel<Guid>>
    {
        private readonly IDataContext _dataContext;
        public DeleteProjectByIdCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<Guid>> Handle(DeleteProjectByIdCommand request, CancellationToken cancellationToken)
        {
            var project = _dataContext.Projects.FirstOrDefault(p => p.Id.Equals(request.Model.Id));
            
            _dataContext.Projects.Remove(project);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return new ResponseModel<Guid>
            {
                ErrorMessage = "",
                IsError = false,
                ResponseValue = request.Model.Id,
            };
        }
    }
}
