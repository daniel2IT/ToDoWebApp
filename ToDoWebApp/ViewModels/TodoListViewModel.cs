using System.Collections.Generic;
using ToDoWebApp.Models;

namespace ToDoWebApp.ViewModels
{
    /* Deka jam mes galime, saugoti keleta/viena objektu/a ir perduoti i HTML sablona */
    public class TodoListViewModel
    {
        public IEnumerable<TodoItem> todoItems { get; set; }
    }
}
