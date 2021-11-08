using Application.Departments.Queries;
using Application.Departments.Queries.GetDepartmentDropDown;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/departments")]
    public class DepartmentAPIController : BaseController
    {
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<JsonResult> GetDepartmentById(Guid id)
        {
            var result = await Mediator.Send(new GetDepartmentByIdQuery() { Id = id });
            return new JsonResult(result);
        }
        [HttpGet]
        [Route("GetDropDown")]
        public async Task<JsonResult> GetDropDown()
        {
            var resp = await Mediator.Send(new GetDepartmentDropDownQuery());
            return new JsonResult(resp);
        }
    }
}
