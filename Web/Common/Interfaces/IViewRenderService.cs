using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Dynamic;
using System.Threading.Tasks;

namespace Web.Common.Interfaces
{
    public interface IViewRenderService
    {
        Task<string> RenderToString(string viewName, object model, ModelStateDictionary modelStateDictionary, ExpandoObject viewBag);
    }
}
