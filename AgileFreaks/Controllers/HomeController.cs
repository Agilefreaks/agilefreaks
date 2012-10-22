using System.Web.Mvc;
using AgileFreaks.Models;

namespace AgileFreaks.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var todoItem = new TodoItem { Title = "Single Page Applicatio Test" };

            return View(todoItem);
        }
    }
}
