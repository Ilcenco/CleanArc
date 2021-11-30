using Application.Common.Interfaces;
using Application.Projects.ViewModels;
using CleanArc.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.Projects.Queries.GetProjectDataTable
{
    class GetProjectDataTableQueryHandler : IRequestHandler<GetProjectDataTableQuery, IEnumerable<ProjectDetailsViewModel>>
    {
        private readonly IDataContext _dataContext;
        public GetProjectDataTableQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<ProjectDetailsViewModel>> Handle(GetProjectDataTableQuery request, CancellationToken cancellationToken)
        {
            // Create Initial Project List to Work With
            IEnumerable < ProjectDetailsViewModel > projects = await _dataContext.Projects.Select(s => new ProjectDetailsViewModel()
            {
                Id = s.Id,
                Name = s.Name,
                DepartmentId = s.DepartmentId,
                DepartmentName = _dataContext.Departments.FirstOrDefault(d => d.Id.Equals(s.DepartmentId)).Name,
                CedacriInternationalRUser = s.CedacriInternationalRUser,
                CedacriInternationalUserName = _dataContext.IdentityUsers.FirstOrDefault(d => d.Id.Equals(s.CedacriInternationalRUser.ToString())).UserName,
                CedacriItalyRUser = s.CedacriItalyRUser,
                CedacriItalyUserName = _dataContext.IdentityUsers.FirstOrDefault(d => d.Id.Equals(s.CedacriItalyRUser.ToString())).UserName,
            })
            .Search(request.Model)
            .OrderBy(request.Model)
            .Page(request.Model)
            .ToListAsync(cancellationToken);
            return projects;
        }
    }
}
