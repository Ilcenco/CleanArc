using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects.Commands.UpdateProject
{
    public class ProjectUpdateByIdCommandHandler : IRequestHandler<ProjectUpdateByIdCommand, ResponseModel<Guid>>
    {
        private readonly IDataContext _dataContext;
        public ProjectUpdateByIdCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<Guid>> Handle(ProjectUpdateByIdCommand request, CancellationToken cancellationToken)
        {
            var project = await _dataContext.Projects.FirstOrDefaultAsync(p => p.Id == request.Model.Id);
            project.Name = request.Model.Name;
            project.DepartmentId = request.Model.DepartmentId;
            project.CedacriInternationalRUser = request.Model.CedacriInternationalRUser;
            project.CedacriItalyRUser = request.Model.CedacriItalyRUser;
            _dataContext.Projects.Update(project);
            await _dataContext.SaveChangesAsync(cancellationToken);

            var responseModel = new ResponseModel<Guid>
            {
                ResponseValue = project.Id,
                IsError = false,
                ErrorMessage = ""
            };

            return responseModel;
        }
    }
}
