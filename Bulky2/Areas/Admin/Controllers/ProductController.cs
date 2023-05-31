using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.InterfaceRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        // Create and Update Action = Upsert
        // ============================================
        public IActionResult Upsert(int? id)
        {
            ProductViewModel productVM = new ProductViewModel()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                Product = new Product()
            };

            if (id == null || id == 0)
            {
                // Create
                return View(productVM);
            } else {
                // Update
                productVM.Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
                return View(productVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Product obj, IFormFile? file)
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
