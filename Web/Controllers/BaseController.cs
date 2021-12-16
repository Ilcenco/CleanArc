using CleanArc.Common.DataTableModels;
using CleanArc.Common.JsonResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Web.Common.Classes;
using Web.Common.Interfaces;
using static Web.Common.Enums;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        private IMediator _mediator;
        private IViewRenderService _viewRenderService;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IViewRenderService ViewRenderService => _viewRenderService ??= HttpContext.RequestServices.GetService<IViewRenderService>();

        protected virtual IActionResult CreateDataTableResult<RecordModelT>(IEnumerable<RecordModelT> records, DataTablesParameters parameters) where RecordModelT : class, new()
        {
            return Json(new DataTableJsonResponse<RecordModelT> { Draw = parameters.Draw, RecordsTotal = parameters.TotalCount, RecordsFiltered = parameters.TotalCount, Data = records });
        }

        protected virtual IActionResult CreateDataTableError(string message)
        {
            return Json(new DataTableJsonResponse<string> { Draw = 0, RecordsTotal = 0, RecordsFiltered = 0, Data = Array.Empty<string>(), Error = message });
        }

        protected virtual async Task<IActionResult> CreateJsonNotValidResultViewAsync(string viewName, object model = null, ModelStateDictionary modelStateDictionary = null, ExpandoObject viewBag = null)
        {
            if (string.IsNullOrWhiteSpace(viewName))
            {
                return Json(new ViewResultJsonResponse { Result = ExecutionResult.OK, ViewHtml = string.Empty });
            }
            string viewHtml = await ViewRenderService.RenderToString(viewName, model, modelStateDictionary, viewBag);
            return Json(new ViewResultJsonResponse { Result = ExecutionResult.NOTVALID, ViewHtml = viewHtml });
        }
          
        protected virtual async Task<IActionResult> CreateJsonResultViewAsync(string viewName, object model = null, ModelStateDictionary modelStateDictionary = null, ExpandoObject viewBag = null)
        {
            if (string.IsNullOrWhiteSpace(viewName))
            {
                return Json(new ViewResultJsonResponse { Result = ExecutionResult.OK, ViewHtml = string.Empty });
            }
            string viewHtml = await ViewRenderService.RenderToString(viewName, model, modelStateDictionary, viewBag);
            return Json(new ViewResultJsonResponse { Result = ExecutionResult.OK, ViewHtml = viewHtml });
        }
        
    }
}
