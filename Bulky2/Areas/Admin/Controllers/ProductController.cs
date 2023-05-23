using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.InterfaceRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        // ============================================
        // Class's Constructor
        // ============================================
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ============================================
        // Index Action
        // ============================================
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        // ============================================
        // Create Action
        // ============================================
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
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

            Product? productFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == ID);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
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

            Product? productFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == ID);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePOST(int? ID)
        {
            if (ID == 0 || ID == null)
            {
                return NotFound();
            }

            Product? productFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == ID);
            if (productFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(productFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
