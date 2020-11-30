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

        public TodoAPIRepository()
        {
            Add(new TodoItem
            {
                Name = "Item1",
                Description = "Description1",
                priority = 1
            });
            Add(new TodoItem
            {
                Name = "Item2",
                Description = "Description2",
                priority = 3
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