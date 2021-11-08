using Application.Common;
using Application.Common.Interfaces;
using CleanArc.Application.Services.Projects.Commands.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
                }).SingleOrDefaultAsync(cancellationToken);
            return responseModel;
        }
    }
}
