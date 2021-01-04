using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Models;

namespace ToDoWebApp.Services
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        IEnumerable<Category> GetAll();
        Category Find(string key);
    }
}
