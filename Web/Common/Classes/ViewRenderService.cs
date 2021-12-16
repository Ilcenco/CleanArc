using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;
using Web.Common.Interfaces;

namespace Web.Common
{
    public class ViewRenderService : IViewRenderService
    {
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IHttpContextAccessor _contextAccessor; 
        public ViewRenderService(IRazorViewEngine razorViewEngine,
        ITempDataProvider tempDataProvider,
        IHttpContextAccessor contextAccessor)
        {
            _razorViewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;
            _contextAccessor = contextAccessor;
        }
        public Task<string> RenderToString(string viewName, object model, ModelStateDictionary modelStateDictionary, ExpandoObject viewBag)
        {
            var actionContext = new ActionContext(_contextAccessor.HttpContext, _contextAccessor.HttpContext.GetRouteData(), new ActionDescriptor());
            ViewEngineResult viewResult = _razorViewEngine.FindView(actionContext, viewName, false);
            if (viewResult.View == null)
            {
                throw new ArgumentNullException($"{viewName} does not match any available view");
            }
            ViewDataDictionary viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), modelStateDictionary ?? new ModelStateDictionary())
            {
                Model = model
            }; 
            IDictionary<string, object> parsedViewBag = viewBag as IDictionary<string, object>;
            if (viewBag != null)
            {
                foreach (KeyValuePair<string, object> keyValuePair in parsedViewBag)
                {
                    viewDictionary.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }
            return RenderToStringAsync(actionContext, viewResult.View, viewDictionary);
        }
        private async Task<string> RenderToStringAsync(ActionContext actionContext, IView view, ViewDataDictionary viewDictionary)
        {
            using var stringWriter = new StringWriter();
            var viewContext = new ViewContext(actionContext,
            view,
            viewDictionary,
            new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
            stringWriter, new HtmlHelperOptions()); await view.RenderAsync(viewContext);
            return stringWriter.ToString();
        }
    }

}
