using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Models;

namespace ToDoWebApp.Data.Intefaces
{
    public interface ITodoItemRepository
    {
        /* uses to get all TodoITems */
        IEnumerable<TodoItem> todoItems { get; }
    }
}
