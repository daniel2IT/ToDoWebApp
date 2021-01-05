using System.Collections.Generic;
using ToDoWebApp.Models;

namespace ToDoWebApp.Data.Intefaces
{
    public interface ITodoItemRepository
    {
        /* uses to get all TodoITems */
        IEnumerable<TodoItem> todoItems
        {
            get;
        }
    }
}