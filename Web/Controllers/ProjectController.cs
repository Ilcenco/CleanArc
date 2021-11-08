using Application.Projects.Commands.AddProject;
using Application.Projects.Commands.UpdateProject;
using CleanArc.Application.Services.Projects.Commands.ViewModels;
using CleanArc.Application.Services.Projects.Queries.GetProjectVmById;
using CleanArc.Application.Services.Projects.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("projects")]
    public class ProjectController : BaseController
    {
        /// <summary>
        /// Create Project 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => View("~/Views/Project/Create.cshtml"));
            //return await ViewAsync("~/Views/Project/Create.cshtml");
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProjectAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(new AddProjectCommand() { projectAdd = vm });
                return Redirect("https://localhost:44337/home/projects?adress=projects");
            }
            return View(vm);
        }


        /// <summary>
        /// Upsert
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Upsert/{id}")]
        public async Task<IActionResult> Upsert(Guid id)
        {
            var vm = (await Mediator.Send(new GetProjectVmByIdQuery() { Id = id })).ResponseValue;


            ViewBag.Model = vm;
            return View("~/Views/Project/Edit.cshtml");
        }

        [HttpPost]
        [Route("Upsert")]
        public async Task<IActionResult> Upsert([FromForm] ProjectUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(new ProjectUpdateByIdCommand() { Model = vm });
                return Redirect("https://localhost:44337/home/projects?adress=projects");
            }
            return View(vm);
        }
    }
}
