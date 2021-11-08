using Application.Common;
using Application.Common.Interfaces;
using Application.Departments.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Departments.Queries
{
    class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, ResponseModel<DepartmentDetailsViewModel>>
    {
        private readonly IDataContext _dataContext;
        public GetDepartmentByIdQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<DepartmentDetailsViewModel>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var responseModel = new ResponseModel<DepartmentDetailsViewModel>
            {
                ErrorMessage = "",
                IsError = false,
            };
            responseModel.ResponseValue = await _dataContext.Departments
                .Where(p => p.Id.Equals(request.Id))
                .Select(s => new DepartmentDetailsViewModel()
            {
                Id = s.Id,
                Name = s.Name,
            }).SingleOrDefaultAsync(cancellationToken);
            return responseModel;
        }
    }
}
