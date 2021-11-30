using Application.Common;
using MediatR;
using System.Collections.Generic;

namespace Application.Departments.Queries.GetDepartmentDropDown
{
    public class GetDepartmentDropDownQuery : IRequest<ResponseModel<IList<DropDownList>>>
    {

    }
}
