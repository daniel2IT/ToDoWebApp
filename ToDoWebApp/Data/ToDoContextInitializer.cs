using System;
using System.Linq;
using ToDoWebApp.Models;

namespace ToDoWebApp.Data
{
    public static class ToDoContextInitializer
    {
        public static void Initialize(ToDoContext context)
        {
            context.Database.EnsureCreated();


            var toDoItem = new TodoItem[]
         {
            new TodoItem{Name="Chemistry", Description="Description", priority=2, CreatedDate= DateTime.UtcNow, DeadLineDate= DateTime.UtcNow, status = default},
            new TodoItem{Name="Microeconomics", Description="Description", priority=2, CreatedDate= DateTime.UtcNow, DeadLineDate= DateTime.UtcNow, status = default},
            new TodoItem{Name="Macroeconomics", Description="Description", priority=2, CreatedDate= DateTime.UtcNow, DeadLineDate= DateTime.UtcNow, status = default},
            new TodoItem{Name="Calculus", Description="Description", priority=2, CreatedDate= DateTime.UtcNow, DeadLineDate= DateTime.UtcNow, status = default},
            new TodoItem{Name="Trigonometry", Description="Description", priority=2, CreatedDate= DateTime.UtcNow, DeadLineDate= DateTime.UtcNow, status = default},
            new TodoItem{Name="Composition", Description="Description", priority=2, CreatedDate= DateTime.UtcNow, DeadLineDate= DateTime.UtcNow, status = default},
            new TodoItem{Name="Literature", Description="Description", priority=2, CreatedDate= DateTime.UtcNow, DeadLineDate= DateTime.UtcNow, status = default}
         };
            foreach (TodoItem c in toDoItem)
            {
                if (context.TodoItem.Any(x => x.Name == c.Name))
                {
                }
                else
                {
                    context.TodoItem.Add(c);
                }
            }
            context.SaveChanges();


            var courses = new Category[]
          {
            new Category{Name="Chemistry"},
            new Category{Name="Microeconomics"},
            new Category{Name="Macroeconomics"},
            new Category{Name="Calculus"},
            new Category{Name="Trigonometry"},
            new Category{Name="Composition"},
            new Category{Name="Literature"}
          };
            foreach (Category c in courses)
            {
                if (context.Categories.Any(x => x.Name == c.Name))
                {
                }
                else
                {
                    context.Categories.Add(c);
                }
            }
            context.SaveChanges();
        }
    }
}
