using System.Collections.Generic;
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
