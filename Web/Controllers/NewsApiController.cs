using CleanArc.Application.Services.News.Queries.GetById;
using CleanArc.Application.Services.News.Queries.GetDataTable;
using CleanArc.Common.DataTableModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/news")]
    public class NewsApiController : BaseController
    {
        [HttpPost]
        [Route("getDataTable")]
        public async Task<IActionResult> getDataTable([FromForm] DataTablesParameters param)
        {
            var model = await Mediator.Send(new GetGridQuery() { Model = param });
            return this.CreateDataTableResult(model, param);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var vm = (await Mediator.Send(new GetNewsByIdQuery() { Id = id })).ResponseValue;


            ViewBag.Model = vm;
            return View("~/Views/News/Details.cshtml");
        }

        

    }
}
