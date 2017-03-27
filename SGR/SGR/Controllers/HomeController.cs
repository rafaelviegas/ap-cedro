using System.Linq;
using System.Web.Mvc;
using SGR.Application.Interfaces;

namespace SGR.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }

    }
}