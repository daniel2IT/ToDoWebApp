using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Models;

namespace ToDoWebApp.DataProviders
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }


        public TodoContext(DbContextOptions options) : base(options)
        {
            LoadCategories();
        }

        public void LoadCategories()
        {
            TodoItem todoItem = new TodoItem() { TodoItemId = 1 ,Name = "Item1" , Description = "Description1" , priority = 2 };
            TodoItems.Add(todoItem);
            todoItem = new TodoItem() { TodoItemId = 2 ,Name = "Item2", Description = "Description2", priority = 3 };
            TodoItems.Add(todoItem);
        }

        public List<TodoItem> GetTodoItems()
        {
            return TodoItems.Local.ToList<TodoItem>();
        }


    }
}
