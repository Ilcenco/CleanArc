using Application.Common;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects.Commands.AddProject
{
    class AddProjectCommandHandler : IRequestHandler<AddProjectCommand, ResponseModel<Guid>>
    {
        private readonly IDataContext _dataContext;
        public AddProjectCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<Guid>> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var responseModel = new ResponseModel<Guid>();
            
            var project = new Project()
            {
                Name = request.projectAdd.Name,
                DepartmentId = request.projectAdd.DepartmentId,
                CedacriInternationalRUser = request.projectAdd.CedacriInternationalRUser,
                CedacriItalyRUser = request.projectAdd.CedacriItalyRUser,
            };
            responseModel.ErrorMessage = "";
            responseModel.IsError = false;
            responseModel.ResponseValue = project.Id;

            await _dataContext.Projects.AddAsync(project);
            await _dataContext.SaveChangesAsync(cancellationToken);
            

            return responseModel;
        }
    }
}
