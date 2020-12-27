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
        TodoItem Find(string key);
        TodoItem Remove(string key);
        string Update(Category category);

    }
}
