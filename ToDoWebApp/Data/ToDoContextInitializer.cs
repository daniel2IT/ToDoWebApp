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
            new TodoItem{
                Name="Chemistry",
                Description="Description",
                priority=2,
                CreatedDate= DateTime.UtcNow,
                DeadLineDate= DateTime.UtcNow,
                status = default,
                CategoryId = 2}, /* Need to change CategoryId , but for what ? */
            new TodoItem{Name="Microeconomics", Description="Description", priority=2, CreatedDate= DateTime.UtcNow, DeadLineDate= DateTime.UtcNow, status = default, CategoryId = 1},
            new TodoItem{Name="Macroeconomics", Description="Description", priority=2, CreatedDate= DateTime.UtcNow, DeadLineDate= DateTime.UtcNow, status = default, CategoryId = 3 },
            new TodoItem{Name="Calculus", Description="Description", priority=2, CreatedDate= DateTime.UtcNow, DeadLineDate= DateTime.UtcNow, status = default , CategoryId = 2 },
            new TodoItem{Name="Trigonometry", Description="Description", priority=2, CreatedDate= DateTime.UtcNow, DeadLineDate= DateTime.UtcNow, status = default,  CategoryId = 3},
            new TodoItem{Name="Composition", Description="Description", priority=2, CreatedDate= DateTime.UtcNow, DeadLineDate= DateTime.UtcNow, status = default, CategoryId = 4},
            new TodoItem{Name="Literature", Description="Description", priority=2, CreatedDate= DateTime.UtcNow, DeadLineDate= DateTime.UtcNow, status = default, CategoryId = 5}
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
            new Category{CategoryId = 1,Name="Chemistry"},
            new Category{CategoryId = 2, Name="Microeconomics"},
            new Category{CategoryId = 3, Name="Macroeconomics"},
            new Category{CategoryId = 4, Name="Calculus"},
            new Category{CategoryId = 5, Name="Trigonometry"},
            new Category{CategoryId = 6, Name="Composition"},
            new Category{CategoryId = 7, Name="Literature"}
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
