using CleanArc.Common.DataTableModels;
using CleanArc.Common.JsonResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected virtual IActionResult CreateDataTableResult<RecordModelT>(IEnumerable<RecordModelT> records, DataTablesParameters parameters) where RecordModelT : class, new()
        {
            return Json(new DataTableJsonResponse<RecordModelT> { Draw = parameters.Draw, RecordsTotal = parameters.TotalCount, RecordsFiltered = parameters.TotalCount, Data = records });
        }

        protected virtual IActionResult CreateDataTableError(string message)
        {
            return Json(new DataTableJsonResponse<string> { Draw = 0, RecordsTotal = 0, RecordsFiltered = 0, Data = Array.Empty<string>(), Error = message });
        }
    }
}
