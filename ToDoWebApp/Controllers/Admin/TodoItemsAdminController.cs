using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoWebApp.Data;
using ToDoWebApp.Models;

namespace ToDoWebApp.Controllers.Admin
{
    public class TodoItemsAdminController : Controller
    {
        private readonly ToDoContext _context;

        public TodoItemsAdminController(ToDoContext context)
        {
            _context = context;
        }

        // GET: TodoItemsOneToManyAdmin
        public async Task<IActionResult> Index()
        {
            var toDoContext = _context.TodoItem.Include(t => t.Category);
            return View(await toDoContext.ToListAsync());
        }

        // GET: TodoItemsOneToManyAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _context.TodoItem
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.TodoItemId == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        // GET: TodoItemsOneToManyAdmin/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: TodoItemsOneToManyAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TodoItemId,Name,Description,CreatedDate,DeadLineDate,priority,status,CategoryId")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", todoItem.CategoryId);
            return View(todoItem);
        }

        // GET: TodoItemsOneToManyAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _context.TodoItem.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", todoItem.CategoryId);
            return View(todoItem);
        }

        // POST: TodoItemsOneToManyAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TodoItemId,Name,Description,CreatedDate,DeadLineDate,priority,status,CategoryId")] TodoItem todoItem)
        {
            if (id != todoItem.TodoItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoItemExists(todoItem.TodoItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", todoItem.CategoryId);
            return View(todoItem);
        }

        // GET: TodoItemsOneToManyAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _context.TodoItem
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.TodoItemId == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        // POST: TodoItemsOneToManyAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todoItem = await _context.TodoItem.FindAsync(id);
            _context.TodoItem.Remove(todoItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoItemExists(int id)
        {
            return _context.TodoItem.Any(e => e.TodoItemId == id);
        }
    }
}
