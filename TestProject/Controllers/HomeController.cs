using System.Web.Mvc;

namespace Testproject.Controllers
{
    public class HomeController : Controller
    {
        // Action Methods

        public ActionResult Index()
        {
            return View();
        }
    }
}