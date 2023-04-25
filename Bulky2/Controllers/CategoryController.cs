using Bulky2.Data;
using Bulky2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky2.Controllers
{
    public class CategoryController : Controller
    {
        // NOTE: Class param for DB context to share in between different
        //       controller methods.
        private readonly ApplicationDbContext _db;

        // Class's Constructor
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Index Action
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        // Create Action
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
