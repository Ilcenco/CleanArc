using Application.Common;
using Application.Common.Interfaces;
using Application.Projects.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects.Queries.GetProjectPage
{
    class GetProjectPageQueryHandler : IRequestHandler<GetProjectPageQuery, ResponseModel<IList<ProjectDetailsViewModel>>>
    {
        private readonly IDataContext _dataContext;
        public GetProjectPageQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<IList<ProjectDetailsViewModel>>> Handle(GetProjectPageQuery request, CancellationToken cancellationToken)
        {

            var responseModel = new ResponseModel<IList<ProjectDetailsViewModel>>();
            responseModel.ErrorMessage = "";
            responseModel.IsError = false;
            var pageIndex = request.PageIndex;
            var pageSize = request.PageSize;
            var filter = request.Filter;

            if (filter == null)
            {
                responseModel.ResponseValue = await _dataContext.Projects
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Select(s => new ProjectDetailsViewModel()
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
                responseModel.totalItems = _dataContext.Projects.Count();
                responseModel.totalPages = (int)Math.Ceiling(responseModel.totalItems / (double)pageSize);
            }
            else
            {
                responseModel.ResponseValue = await _dataContext.Projects
                    .Where(p => p.Name.Contains(filter))
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Select(s => new ProjectDetailsViewModel()
                {
                    Name = s.Name,
                    Id = s.Id,
                    DepartmentId = s.DepartmentId,
                    CedacriInternationalRUser = s.CedacriInternationalRUser,
                    CedacriItalyRUser = s.CedacriItalyRUser,
                }).ToListAsync(cancellationToken);
                responseModel.totalItems = _dataContext.Projects.Where(p => p.Name.Contains(filter)).Count();
                responseModel.totalPages = (int)Math.Ceiling(responseModel.totalItems / (double)pageSize);
            }

            return responseModel;
        }
    }
}
