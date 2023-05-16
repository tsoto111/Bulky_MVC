using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.InterfaceRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky2.Controllers
{
    public class CategoryController : Controller
    {
        // NOTE: Class param for DB context to share in between different
        //       controller methods.
        private readonly ICategoryRepository _categoryRepo;

        // ============================================
        // Class's Constructor
        // ============================================
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }

        // ============================================
        // Index Action
        // ============================================
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
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
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
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

            Category? categoryFromDb = _categoryRepo.GetFirstOrDefault(u => u.Id == ID);
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
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
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

            Category? categoryFromDb = _categoryRepo.GetFirstOrDefault(u => u.Id == ID);
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

            Category? categoryFromDb = _categoryRepo.GetFirstOrDefault(u => u.Id == ID);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            _categoryRepo.Remove(categoryFromDb);
            _categoryRepo.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
