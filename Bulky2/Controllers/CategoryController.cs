using Microsoft.AspNetCore.Mvc;

namespace Bulky2.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
