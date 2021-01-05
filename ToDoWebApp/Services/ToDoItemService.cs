using System.Collections.Generic;
using ToDoWebApp.Models;
using ToDoWebApp.Repository;

namespace ToDoWebApp.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly TodoAPIRepository TodoItems;
        public ToDoItemService(TodoAPIRepository todoItems)
        {
            TodoItems = todoItems;
        }

        public string Add(TodoItem item)
        {
            if (item == null)
            {
                return "False";
            }

            if(item.priority >= 0 )
            {
                if(item.priority <= 5)
                {  
                TodoItems.Add(item);
                    return "True";
                }
            }
            else
            {
                return "False";
            }
            return "False";
        }

        public TodoItem Find(string key)
        {
            return TodoItems.Find(key);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            /*  return TodoItems.GetAll();*/
            return TodoItems.GetAll();
        }

        public TodoItem Remove(string key)
        {
            return TodoItems.Remove(key);
        }

        public string Update(TodoItem item)
        {
            if (item == null)
            {
                return "False";
            }

            if (item.priority >= 0)
            {
                if (item.priority <= 5)
                {
                    TodoItems.Update(item);
                    return "True";
                }
            }
            else
            {
                return "False";
            }
            return "False";
        }
    }
}
