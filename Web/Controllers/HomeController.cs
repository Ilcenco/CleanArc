using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Users()
        {
            return View();
        }
        [Authorize]
        public IActionResult Projects()
        {

            return View();
        }
        [Authorize]
        public IActionResult ProjectsDataTable()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }



    }
}
