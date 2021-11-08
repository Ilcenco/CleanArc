using Application.Common;
using MediatR;
using System.Collections.Generic;

namespace Application.Users.Queries.GetUserDropDown
{
    public class GetUserDropDownQuery : IRequest<ResponseModel<IList<DropDownList>>>
    {
    }
}
