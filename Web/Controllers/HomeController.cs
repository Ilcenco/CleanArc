using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        //[Authorize]
        public IActionResult Projects()
        {

            return View();
        }
        public IActionResult ProjectsDataTable()
        {
            return View();
        }



    }
}
