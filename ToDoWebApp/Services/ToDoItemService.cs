using System;
using System.Collections.Generic;
using System.Linq;
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
            DateTime dt;
            dt =  DateTime.Now;

            if (item == null)
            {
                return "False";
            }



            // Create a list of Items to Check Name Exists or Not ...
            IEnumerable<TodoItem> GetAll = TodoItems.GetAll();
            List<TodoItem> primeNumbers = GetAll.ToList();

            var names = primeNumbers.FirstOrDefault(m => m.Name == item.Name);

            if(names != null)
            {
                throw new ArgumentException("NameAlreadyExists");
            }
   

            if (item.priority >= 0 )
            {
                if(item.priority <= 5)
                {

                    if (item.DeadLineDate != null)
                    {
                        int result = DateTime.Compare(item.DeadLineDate.GetValueOrDefault(), dt);

                        if (result < 0)
                            return "BAD";
                        /*   throw new ArgumentException("is earlier than"); // anksciau(ranshe) ...*/
                        else if (result == 0)
                            return "BAD";
                        /* throw new ArgumentException("is the same time as");*/
                        else
                            throw new ArgumentException("DeadLine is later than TodayDate");
                    }

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

            // Create a list of Items to Check Name Exists or Not ...
            IEnumerable<TodoItem> GetAll = TodoItems.GetAll();
            List<TodoItem> primeNumbers = GetAll.ToList();

            var names = primeNumbers.FirstOrDefault(m => m.Name == item.Name);

            if (names != null){ 
            
                throw new ArgumentException("NameAlreadyExists");
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
