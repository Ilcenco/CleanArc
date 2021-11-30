using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Url.Queries.GetUrlTypesDropDown
{
    public class GetUrlTypesDropDownQuery : IRequest<ResponseModel<IList<DropDownList>>>
    {

    }
}
