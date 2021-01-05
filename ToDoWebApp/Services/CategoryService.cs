using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public Category Find(string key)
        {
            var categoryFind = context.Categories.FirstOrDefault(s => s.Name == key);
            if (categoryFind == null)
            {
                throw new ArgumentException("bad category");
            }
            return null;
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories;
        }

        public Category Remove(string key)
        {
            throw new NotImplementedException();
        }

        public string Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
