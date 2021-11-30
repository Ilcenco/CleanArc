using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.Url.Queries.GetUrlTypesDropDown
{
    public class GetUrlTypesDropDownQueryHandler : IRequestHandler<GetUrlTypesDropDownQuery, ResponseModel<IList<DropDownList>>>
    {
        private readonly IDataContext _dataContext;
        public GetUrlTypesDropDownQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<IList<DropDownList>>> Handle(GetUrlTypesDropDownQuery request, CancellationToken cancellationToken)
        {
            return new ResponseModel<IList<DropDownList>>()
            {
                IsError = false,
                ErrorMessage = "",
                ResponseValue = await _dataContext.UrlTypes.Select(s => new DropDownList()
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToListAsync(cancellationToken)
            };
        }
    }
}
