using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ToDoWebApp.Data.Intefaces;
using ToDoWebApp.Models;
using ToDoWebApp.Repository;

namespace ToDoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoAPIController : ControllerBase
    {
     /*   public static List<Category> asList;
        public static bool Passed;*/

        public TodoAPIController(ITodoItemAPIRepository todoItems)
        {
            TodoItems = todoItems;
        }
        public ITodoItemAPIRepository TodoItems { get; set; }


        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")] /*Req Just By Name */
        public IActionResult GetById(string id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item) /* The [FromBody] attribute tells MVC to get 
                                                               * the value of the to-do item from the body 
                                                               * of the HTTP request.
                                                               * Req Just By Name */
        {
            if (item == null)
            {
                return BadRequest();
            }
            TodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.TodoItemId }, item);
        }


        [HttpPut("{id}")] /*Req Just By Name */
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var todo = TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            TodoItems.Update(item);
            return new NoContentResult();
        }


        [HttpDelete("{id}")] /*Req Just By Name */
        public void Delete(string id)
        {
            TodoItems.Remove(id);
        }

    }
}
