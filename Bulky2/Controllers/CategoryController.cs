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

        // ============================================
        // Class's Constructor
        // ============================================
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // ============================================
        // Index Action
        // ============================================
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        // ============================================
        // Create Action
        // ============================================
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            /*
            // Example of a Custom validation added to the NAME field.
            if(obj.ValidateFieldsMatch(obj))
            {
                ModelState.AddModelError("name", "The \"Display Order\" cannot exactly match the \"Category Name\".");
            }
            */

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        // ============================================
        // Edit Action
        // ============================================
        public IActionResult Edit(int? ID)
        {
            if (ID == 0 || ID == null)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(ID);
            // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(c => c.Id == ID); // Another way to query a single record by ID.
            // Category? categoryFromDb2 = _db.Categories.Where(u => u.Id === ID).FirstOrDefault(); // Another way to query a single record by ID.
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {   
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        // ============================================
        // Delete Action
        // ============================================
        public ActionResult Delete(int? ID)
        {
            if (ID == 0 || ID == null)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(ID);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePOST(int? ID)
        {
            if (ID == 0 || ID == null)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(ID);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(categoryFromDb);
            _db.SaveChanges(true);
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
