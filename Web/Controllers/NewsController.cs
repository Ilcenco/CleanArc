using CleanArc.Application.Services.News.Commands.AddNews;
using CleanArc.Application.Services.News.Commands.DeleteNews;
using CleanArc.Application.Services.News.Commands.UpdateNews;
using CleanArc.Application.Services.News.Queries.GetById;
using CleanArc.Application.Services.News.ViewModels;
using CleanArc.Application.Services.Users.Queries.GetUserType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Web.Common;

namespace Web.Controllers
{
    [Route("news")]

    public class NewsController : BaseController
    {
        /// <summary>
        /// Create Project 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => View("~/Views/News/Create.cshtml"));
            //return await ViewAsync("~/Views/Project/Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] NewsAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                lock (StaticLogs.Logs)
                {
                    StaticLogs.Logs.Add("Created news: " + vm.Title);
                }
                var result = await Mediator.Send(new AddNewsCommand() { Model = vm });
                return Json(result);

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
            var vm = (await Mediator.Send(new GetNewsByIdQuery() { Id = id })).ResponseValue;


            ViewBag.Model = vm;
            return View("~/Views/News/Edit.cshtml");
        }

        [HttpPost]
        [Route("Upsert")]
        public async Task<IActionResult> Upsert([FromForm] UpdateNewsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                lock (StaticLogs.Logs)
                {
                    StaticLogs.Logs.Add("Updated news: " + vm.Title);
                }
                return Json(await Mediator.Send(new UpdateNewsCommand() { Model = vm }));
            }
            return View(vm);
        }


        [HttpDelete]
        [Route("DeleteConfirmation/{id}")]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            ViewBag.Id = id;
            return View("~/Views/Home/Delete.cshtml");
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromForm] Guid id)
        {
            lock (StaticLogs.Logs)
            {
                StaticLogs.Logs.Add("Deleted project: " + id);
            }
            await Mediator.Send(new DeleteNewsByIdCommand() { Id = id });
            return Redirect("https://localhost:44337/home/newsdatatable");
        }


        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var vm = (await Mediator.Send(new GetNewsByIdQuery() { Id = id })).ResponseValue;

            ViewBag.Model = vm;
            return View("~/Views/News/Details.cshtml");
        }

        [HttpGet]
        [Route("CheckUser")]
        public async Task<string> GetUserType()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                return await Mediator.Send(new GetUserTypeQuery() { Name = currentUser.Identity.Name });
            }
            return "Anonim";
        }
    }
}
