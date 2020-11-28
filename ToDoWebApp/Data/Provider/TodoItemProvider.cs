using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Data.Intefaces;
using ToDoWebApp.Models;

namespace ToDoWebApp.DataProviders
{
    public class TodoItemProvider : ITodoItemRepository
    {
        public IEnumerable<TodoItem> todoItems
        {
            get
            {
                return new List<TodoItem>{
                    
                    new TodoItem
                    {
                        TodoItemId = 1,
                        Name = "Item",
                        Description ="Description",
                        priority = 5
                    },
                    new TodoItem
                    {
                        TodoItemId = 2,
                        Name = "Item1",
                        Description ="Description1",
                        priority = 4
                    },
                    new TodoItem
                    {
                        TodoItemId = 3,
                        Name = "Item2",
                        Description ="Description2",
                        priority = 3
                    },
                    new TodoItem
                    {
                        TodoItemId = 4,
                        Name = "Item3",
                        Description ="Description3",
                        priority = 2
                    },
                    new TodoItem
                    {
                        TodoItemId = 5,
                        Name = "Item4",
                        Description ="Description4",
                        priority = 1
                    }
                };
            }
        }

    }
}
