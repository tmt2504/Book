using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.DataAccess.Data;
using Book.DataAccess.Repository.IRepository;
using Book.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Category> categoryList = _unitOfWork.Category.GetAll().ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		public IActionResult Create(Category category)
		{
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category created sucessfully";
                return RedirectToAction("Index", "Category");
			}
            return View();
            
		}

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryId = _unitOfWork.Category.Get(x=>x.Id==id);
            if (categoryId == null)
            {
                return NotFound();
            }
            return View(categoryId);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category updated sucessfully";
                return RedirectToAction("Index", "Category");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryId = _unitOfWork.Category.Get(x=>x.Id==id);
            if (categoryId == null)
            {
                return NotFound();
            }
            return View(categoryId);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Category? category = _unitOfWork.Category.Get(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
                TempData["success"] = "Category deleted sucessfully";
            return RedirectToAction("Index","Category");

        }
    }
}

