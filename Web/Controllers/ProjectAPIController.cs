using Application.Projects.Commands.AddProject;
using Application.Projects.Commands.DeleteProject;
using Application.Projects.Commands.UpdateProject;
using Application.Projects.Queries.GetProjectById;
using Application.Projects.Queries.GetProjectPage;
using CleanArc.Application.Common.Models;
using CleanArc.Application.Services.Projects.Commands.ViewModels;
using CleanArc.Application.Services.Projects.Queries.GetProjectDataTable;
using CleanArc.Application.Services.Projects.Queries.GetProjectVmById;
using CleanArc.Application.Services.Projects.ViewModels;
using CleanArc.Common.DataTableModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web;

namespace Web.Controllers
{
    [Route("api/projects")]
    public class ProjectAPIController : BaseController
    {
        
        [HttpPost]
        [Route("Add")]    
        public async Task<JsonResult> AddProject([FromForm] ProjectAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                return new JsonResult(await Mediator.Send(new AddProjectCommand() { projectAdd = model }));
            }
            return new JsonResult("OK");
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<JsonResult> Delete(Guid id)
        {

            return new JsonResult(await Mediator.Send(new DeleteProjectByIdCommand() { Model = new ProjectDeleteViewModel() { Id = id} }));
        }


        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllProjects()
        {
            return new JsonResult("Ok");
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<JsonResult> GetProjectById(Guid id)
        {
            return new JsonResult(await Mediator.Send(new GetProjectByIdQuery() { Id = id}));
        }

        [HttpPost]
        [Route("GetVmById/{id}")]
        public async Task<IActionResult> GetProjectVmById(Guid id)
        {
            var vm = await Mediator.Send(new GetProjectVmByIdQuery() { Id = id });
            
            return Json(new  {model = vm, data1 = "text" });
        }


        [HttpPost]
        [Route("GetPage")]
        public async Task<JsonResult> GetPage([FromForm] int pageSize, [FromForm] int pageIndex, [FromForm] string filter)
        {
            return new JsonResult(await Mediator.Send(new GetProjectPageQuery() { Filter = filter, PageIndex = pageIndex, PageSize = pageSize }));
        }


        [HttpPut]
        [Route("Update")]
        public async Task<JsonResult> UpdateProject([FromForm] ProjectUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return new JsonResult(await Mediator.Send(new ProjectUpdateByIdCommand() { Model = model }));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return new JsonResult("Ok");
        }

        [HttpPost]
        [Route("getDataTable")]
        public async Task<IActionResult> getDataTable([FromForm] DataTablesParameters param)
        {
            var model = await Mediator.Send(new GetProjectDataTableQuery() { Model = param});
            return this.CreateDataTableResult(model, param);
        }

        
    }
}
