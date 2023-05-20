using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.DataAccess.Data;
using Book.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Category> categoryList = _db.Category.ToList();
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
				_db.Category.Add(category);
				_db.SaveChanges();
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
            Category ?categoryId = _db.Category.Find(id);
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
                _db.Category.Update(category);
                _db.SaveChanges();
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
            Category? categoryId = _db.Category.Find(id);
            if (categoryId == null)
            {
                return NotFound();
            }
            return View(categoryId);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Category? category = _db.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Category.Remove(category);
            _db.SaveChanges();
                TempData["success"] = "Category deleted sucessfully";
            return RedirectToAction("Index","Category");

        }
    }
}

