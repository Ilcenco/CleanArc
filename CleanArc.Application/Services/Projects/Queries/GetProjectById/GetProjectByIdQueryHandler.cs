using Application.Common;
using Application.Common.Interfaces;
using Application.Projects.ViewModels;
using CleanArc.Application.Services.Projects.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects.Queries.GetProjectById
{
    class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ResponseModel<ProjectDetailsViewModel>>
    {
        private readonly IDataContext _dataContext;
        public GetProjectByIdQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<ProjectDetailsViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var responseModel = new ResponseModel<ProjectDetailsViewModel>
            {
                ErrorMessage = "",
                IsError = false,
            };
           

            responseModel.ResponseValue = await _dataContext.Projects
                .Where(p => p.Id.Equals(request.Id))
                .Select(s => new ProjectDetailsViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    DepartmentId = s.DepartmentId,
                    CedacriInternationalRUser = s.CedacriInternationalRUser,
                    CedacriItalyRUser = s.CedacriItalyRUser,
                    URLs = new List<ProjectRepositoryURLViewModel>()
                }).SingleOrDefaultAsync(cancellationToken);

            

            return responseModel;
        }
    }
}
