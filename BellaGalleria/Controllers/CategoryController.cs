using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BellaGalleria.Model.Models;
using BellaGalleria.Data;
using BellaGalleria.Service;

namespace BellaGalleria.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _category;

        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        // GET: /Category/
        public ActionResult Index()
        {
            var Categories = _category.GetCategories();
            return View(Categories);
        }

        // GET: /Category/Details/5
        public ActionResult Details(int id)
        {
            Category category = _category.GetCategory(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: /Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _category.CreateCategory(category);
                _category.SaveCategory();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: /Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = _category.GetCategory(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: /Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _category.EditCategory(category);
                _category.SaveCategory();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: /Category/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = _category.GetCategory(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: /Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _category.GetCategory(id);
            _category.DeleteCategory(category);
            _category.SaveCategory();
            return RedirectToAction("Index");
        }
        
    }
}
