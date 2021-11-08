using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserDropDown
{
    class GetUserDropDownQueryHandler : IRequestHandler<GetUserDropDownQuery, ResponseModel<IList<DropDownList>>>
    {
        private readonly IDataContext _dataContext;
        public GetUserDropDownQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<IList<DropDownList>>> Handle(GetUserDropDownQuery request, CancellationToken cancellationToken)
        {

            var rM = new ResponseModel<IList<DropDownList>>();
            if (_dataContext.IdentityUsers.Any())
            {
                rM.IsError = false;
                rM.ErrorMessage = "";
                rM.ResponseValue = await _dataContext.IdentityUsers.Select(s => new DropDownList()
                {
                    Id = Guid.Parse(s.Id),
                    Name = s.UserName,
                }).ToListAsync(cancellationToken);
            }
            else
            {
                rM.IsError = true;
                rM.ErrorMessage = "Not found any users";
                rM.ResponseValue = null;
            }
            return rM;
        }
    }
}
