using System.Collections.Generic;
using ToDoWebApp.Models;

namespace ToDoWebApp.Data.Intefaces
{
    public interface ITodoItemAPIRepository
    {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(string key);
        TodoItem Remove(string key);
        void Update(TodoItem item);
    }
}