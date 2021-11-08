using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Departments.Queries.GetDepartmentDropDown
{
    class GetDepartmentDropDownQueryHandler : IRequestHandler<GetDepartmentDropDownQuery, ResponseModel<IList<DropDownList>>>
    {
        private readonly IDataContext _dataContext;
        public GetDepartmentDropDownQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ResponseModel<IList<DropDownList>>> Handle(GetDepartmentDropDownQuery request, CancellationToken cancellationToken)
        {
            return new ResponseModel<IList<DropDownList>>()
            {
                IsError = false,
                ErrorMessage = "",
                ResponseValue = await _dataContext.Departments.Select(s => new DropDownList()
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToListAsync(cancellationToken)
            };
        }
    }
}
