using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Data.Intefaces;
using ToDoWebApp.Models;
using ToDoWebApp.ViewModels;

namespace ToDoWebApp.Controllers
{
    public class TodoItemsController : Controller
    {
        public static List<TodoItem> asList;
        public static bool pereita;

        public TodoItemsController(ITodoItemRepository todoItemRepository)
        {
            if (pereita.Equals(false)) { 
               asList = todoItemRepository.todoItems.ToList();
                pereita = true;
                
            }
        }
    

        // GET: TodoItemsController
        public ActionResult Index()
        {
            return View(asList); 
        }

        // GET: TodoItemsController/Details/5
        public ActionResult Details(int id)
        {
            return View(model: asList.FirstOrDefault(predicate: s => s.TodoItemId == id));
        }

        // GET: TodoItemsController/Create
        public ActionResult Create()
        {
            return View( new TodoItem { Name = "Type Here" });
        }

        // POST: TodoItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TodoItem todoItem)
        {
            try
            {
                // duodame prieiga prie duom
                asList.Add(todoItem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(todoItem);
            }
        }

        // GET: TodoItemsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TodoItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TodoItem todoItem)
        {

            try
            {
                foreach(var s in asList){

                    if (s.TodoItemId.Equals(id))
                    {
                        s.Name = todoItem.Name;
                        s.Description = todoItem.Description;
                        s.priority = todoItem.priority;
                        break;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(todoItem);
            }
        }

        // GET: TodoItemsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(model: asList.FirstOrDefault(predicate: s => s.TodoItemId == id));
        }

        // POST: TodoItemsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TodoItem todoItem)
        {

            try
            {

                asList.RemoveAll(x => x.TodoItemId == id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
