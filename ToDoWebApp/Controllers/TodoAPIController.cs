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
        public TodoAPIController(TodoAPIRepository todoItems)
        {
            TodoItems = todoItems;
        }
        public ITodoItemAPIRepository TodoItems { get; set; }


        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
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
                                                               * of the HTTP request.*/
        {
            if (item == null)
            {
                return BadRequest();
            }
            TodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.TodoItemId }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || Convert.ToString(item.TodoItemId) != id)
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

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            TodoItems.Remove(id);
        }

    }
}
