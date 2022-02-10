using ElevenNote.Data;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var svc = CreateCategoryService();
            return View(svc.GetCategories());
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if(!ModelState.IsValid)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var svc = CreateCategoryService();

            if (svc.CreateCategory(category))
            {
                TempData["SaveResult"] = "Your category was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Category could not be created.");
            return View(category);
        }

        // GET: Category/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateCategoryService();

            var category = svc.GetCategoryByID(id);

            return View(category);
        }

        // POST: Category/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if(id != category.CategoryId)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(category);
            }
                
            var svc = CreateCategoryService();

            if (svc.UpdateCategory(category))
            {
                TempData["SaveResult"] = "Category Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Category could not be updated.");

            return View(category);
        }

        // GET: Category/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateCategoryService();
            var category = svc.GetCategoryByID(id);

            return View(category);
        }

        // POST: Category/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            var svc = CreateCategoryService();

            if(svc.DeleteCategory(id))
            {
                TempData["SaveResult"] = "Category Deleted";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Category could not be deleted.");

            return View(svc.GetCategoryByID(id));
        }

        public CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            return service;
        }
    }
}