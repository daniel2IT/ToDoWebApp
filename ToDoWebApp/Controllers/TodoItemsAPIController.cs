using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoWebApp;
using ToDoWebApp.Models;
using ToDoWebApp.DataProviders;

namespace ToDoWebApp.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class TodoItemsAPIController : Controller
    {
        private readonly TodoContext _context; /* TodoApi*/

        public TodoItemsAPIController(TodoContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<TodoItem> categories = _context.GetTodoItems();
            return Ok(categories);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItem todoItem)
        {
            if (id != todoItem.TodoItemId)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



                     // DELETE: api/TodoItems/5
                [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteTodoItem(long id)
                {
                    var todoItem = await _context.TodoItems.FindAsync(id);
                    if (todoItem == null)
                    {
                        return NotFound();
                    }

                    _context.TodoItems.Remove(todoItem);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }

                // POST: api/TodoItems
                [HttpPost]
                public async Task<ActionResult<TodoItem>> Create(TodoItem todoItem)
                {
                    _context.TodoItems.Add(todoItem);
                    await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItems", new { id = todoItem.TodoItemId }, todoItem);
            /* return CreatedAtAction(nameof(_context.GetTodoItems), new { id = todoItem.TodoItemId }, todoItem);*/
        }


        private bool TodoItemExists(int id)
        {
            return _context.TodoItems.Any(e => e.TodoItemId == id);
        }
    }
}
