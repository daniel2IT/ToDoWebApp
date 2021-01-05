using System.Collections.Generic;
using ToDoWebApp.Models;

namespace ToDoWebApp.Services
{
    public interface IToDoItemService
    {
        string Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(string key);
        TodoItem Remove(string key);
        string Update(TodoItem item);
    }
}
