using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Data.Intefaces;
using ToDoWebApp.Models;

namespace ToDoWebApp.Controllers
{
    public class CategoryController : Controller
    {

        public static List<Category> asList;
        public static bool pereita;

        public CategoryController(ICategoryRepository IcategoryRepository)
        {
            if (pereita.Equals(false))
            {
                asList = IcategoryRepository.categories.ToList();
                pereita = true;

            }
        }



        // GET: CategoryController
        public ActionResult Index()
        {
            return View(asList);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View(model: asList.FirstOrDefault(predicate: s => s.CategoryId == id));
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View(new Category { Name = "Type Here" });
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                // duodame prieiga prie duom
                asList.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                foreach (var s in asList)
                {

                    if (s.CategoryId.Equals(id))
                    {
                        s.Name = category.Name;
                        break;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(model: asList.FirstOrDefault(predicate: s => s.CategoryId == id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                asList.RemoveAll(x => x.CategoryId == id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
