using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext db;
        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj) {

            if (ModelState.IsValid)
            {
                db.Categories.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = db.Categories.Find(id);
            if (category == null) { 
                
                return NotFound();
            }

            return View(category);

        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                db.Categories.Update(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = db.Categories.Find(id);
            if (category == null)
            {

                return NotFound();
            }

            return View(category);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            Category? category = db.Categories.Find(id);

            if (category == null)
            {

                return NotFound();
            }
            
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");   

        }

    }
}
