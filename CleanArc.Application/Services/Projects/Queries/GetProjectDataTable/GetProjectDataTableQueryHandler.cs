using Application.Common.Interfaces;
using Application.Projects.ViewModels;
using CleanArc.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.Projects.Queries.GetProjectDataTable
{
    class GetProjectDataTableQueryHandler : IRequestHandler<GetProjectDataTableQuery, ResponseModelDto>
    {
        private readonly IDataContext _dataContext;
        public GetProjectDataTableQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ResponseModelDto> Handle(GetProjectDataTableQuery request, CancellationToken cancellationToken)
        {
            // Init Response Model type
            var reponseModelDto = new ResponseModelDto();


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
            }).ToListAsync(cancellationToken);


            // Apply Filtering on previous computed list
            if (!string.IsNullOrEmpty(request.Model.sSearch))
            {
                projects = projects
                    .Where(x => x.Name.ToLower().Contains(request.Model.sSearch.ToLower())).ToList(); 
            }


            // Apply sorting on our list
            var sortColumnIndex = request.Model.iSortCol_0;
            var sortDirection = request.Model.sSortDir_0;
            if (sortColumnIndex == 1)
            {
                projects = sortDirection == "asc" ? projects.OrderBy(c => c.Name) : projects.OrderByDescending(c => c.Name);
            }


            // Apply Pagination
            var displayResult = projects.Skip(request.Model.iDisplayStart)
               .Take(request.Model.iDisplayLength).ToList();
            var totalRecords = projects.Count();


            // Return
            reponseModelDto.sEcho = request.Model.sEcho;
            reponseModelDto.iTotalRecords = totalRecords;
            reponseModelDto.iTotalDisplayRecords = totalRecords;
            reponseModelDto.aaData = displayResult;
            return reponseModelDto;
        }
    }
}
