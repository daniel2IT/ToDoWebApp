using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDoWebApp.Data;
using ToDoWebApp.Data.Intefaces;
using ToDoWebApp.Models;

namespace ToDoWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ToDoContext context;
/*        public static List<Category> asList;
        public static bool Passed;*/

        public CategoryController(ICategoryRepository IcategoryRepository,
                                   ToDoContext context)
        {
              /*  asList = IcategoryRepository.categories.ToList(); - Static data for API */
                this.context = context;
              /*  asList = context.Categories.ToList();*/
        }

        // GET: CategoryController
        public async Task<IActionResult> Index()
        {
            /* var myCategories = context.Categories.ToList();*/

            return View(await context.Categories.ToListAsync());
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await context.Categories.FindAsync(id));
        }

        // GET: CategoryController/Create
        public async Task<ActionResult> Create()
        {
            return View(new Category
            {
                Name = "Type Here"
            });
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Add(category);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(category);
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            /*return View();*/
            return View(await context.Categories.FindAsync(id));
          /*  return View(context.Categories.FirstOrDefault(s => s.CategoryId == id));*/
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await context.Categories.FirstOrDefaultAsync(s => s.CategoryId == id);
            if (await TryUpdateModelAsync<Category>(
                studentToUpdate,
                "",
                s => s.Name))
            {
                try
                {
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(studentToUpdate);
        }


        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await context.Categories.FindAsync(id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Category categoryToDelete = new Category() { CategoryId = id };
                context.Entry(categoryToDelete).State = EntityState.Deleted;

                context.SaveChangesAsync();
                  return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}