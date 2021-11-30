using Application.Common;
using Application.Common.Interfaces;
using CleanArc.Application.Services.Projects.Commands.ViewModels;
using CleanArc.Application.Services.Projects.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.Projects.Queries.GetProjectVmById
{
    class GetProjectVmByIdQueryHandler : IRequestHandler<GetProjectVmByIdQuery, ResponseModel<ProjectUpdateViewModel>>
    {
        private readonly IDataContext _dataContext;
        public GetProjectVmByIdQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<ProjectUpdateViewModel>> Handle(GetProjectVmByIdQuery request, CancellationToken cancellationToken)
        {
            var responseModel = new ResponseModel<ProjectUpdateViewModel>
            {
                ErrorMessage = "",
                IsError = false,
            };

            responseModel.ResponseValue = await _dataContext.Projects
                .Where(p => p.Id.Equals(request.Id))
                .Select(s => new ProjectUpdateViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    DepartmentId = s.DepartmentId,
                    CedacriInternationalRUser = s.CedacriInternationalRUser,
                    CedacriItalyRUser = s.CedacriItalyRUser,

                    DepartmentsDropDown = _dataContext.Departments.Select(s => new DropDownList()
                    {
                        Id = s.Id,
                        Name = s.Name
                    }).ToList(),
                    UsersDropDown = _dataContext.IdentityUsers.Select(s => new DropDownList()
                    {
                        Id = Guid.Parse(s.Id),
                        Name = s.UserName,
                    }).ToList(),
                    UrlTypesDropDown = _dataContext.UrlTypes.Select(s => new DropDownList()
                    {
                        Id = s.Id,
                        Name = s.Name
                    }).ToList(),
                    URLs = _dataContext.ProjectRepositoriesUrl.Where(u => u.ProjectId.Equals(request.Id)).Select(q => new ProjectRepositoryURLViewModel()
                    {
                        Id = q.Id,
                        Url = q.Url,
                        UrlTypeId = q.UrlTypeId
                    }).ToList()
                }).SingleOrDefaultAsync(cancellationToken);
            return responseModel;
        }
    }
}
