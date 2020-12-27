using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Data;
using ToDoWebApp.Models;

namespace ToDoWebApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ToDoContext context;
        public CategoryService(ToDoContext context)
        {
            this.context = context;
        }

        public void AddCategory(Category category)
        {
            var categoryFind = context.Categories.FirstOrDefault(s => s.Name == category.Name);
           if(categoryFind == null)
            {
                throw new ArgumentException("bad category");
            }
            
            /* context.Add(category);
            context.SaveChangesAsync();*/
        }

        public TodoItem Find(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public TodoItem Remove(string key)
        {
            throw new NotImplementedException();
        }

        public string Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
