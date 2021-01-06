using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ToDoWebApp.Data.Intefaces;
using ToDoWebApp.Models;

namespace ToDoWebApp.Repository
{
    public class TodoAPIRepository : ITodoItemAPIRepository
    {
        public static int counter;
        private static ConcurrentDictionary<string,
        TodoItem> _todos = new ConcurrentDictionary<string,
        TodoItem>();

        public List<TodoItem> todoItem { get; set; } 
        
        public TodoAPIRepository()
        {
            Add(new TodoItem
            {
                TodoItemId = 1,
                Name = "Item1",
                Description = "Description1",
                priority = 1,
                status = Status.Wip,
                DeadLineDate = new DateTime(2088, 3, 9, 7, 0, 0) // 3/1/2088 7:00:00 AM
            });
            Add(new TodoItem
            {
                TodoItemId = 2,
                Name = "Item2",
                Description = "Description2",
                priority = 2,
                status = Status.Wip,
                DeadLineDate = new DateTime(2088, 3, 1, 7, 0, 0) // 3/1/2088 7:00:00 AM
            });
            Add(new TodoItem
            {
                TodoItemId = 3,
                Name = "ItemForTestAlreadeCreated",
                Description = "Description3",
                priority = 2,
                status = Status.Wip,
                DeadLineDate = new DateTime(2088, 3, 3, 7, 0, 0) // 3/1/2088 7:00:00 AM
            });
            Add(new TodoItem
            {
                TodoItemId = 4,
                Name = "ItemForTestAlreadeCreate3232d",
                Description = "Description3",
                priority = 2,
                status = Status.Wip,
                DeadLineDate = new DateTime(2088, 3, 5, 7, 0, 0) // 3/1/2088 7:00:00 AM
            });
            Add(new TodoItem
            {
                TodoItemId = 5,
                Name = "ItemForTestAlreadeCreate3232d",
                Description = "Description3",
                priority = 2,
                status = Status.Planned
            });
        }

        public void Add(TodoItem item)
        {
            counter++;
            /*item.TodoItemId = Guid.NewGuid().GetHashCode(); - bad choice, chance for repeat...*/
            /* ID */
            item.TodoItemId = counter;
            _todos[item.TodoItemId.ToString()] = item;
            
        }

        public TodoItem Find(string key)
        {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public IEnumerable<TodoItem> GetAll() => _todos.Values;
        /* Get All */

        public TodoItem Remove(string key)
        {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(TodoItem item)
        {
            _todos[item.TodoItemId.ToString()] = item;
        }

    
    }
}