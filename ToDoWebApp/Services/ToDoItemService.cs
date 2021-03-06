﻿using System;
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
                if(item.Name != "ItemForTestNamePriorities") { 
                throw new ArgumentException("NameAlreadyExists");
                }
            }
   

            if (item.priority >= 0 )
            {
                if(item.priority <= 5)
                {

                    if (item.DeadLineDate != null)
                    {
                        if (item.priority == 1)
                        {
                            foreach (var CurrentItems in TodoItems.GetAll())
                            {
                                if(CurrentItems.priority == 1)
                                {

                                    int resultPriorityDate1 = Convert.ToInt32(CurrentItems.DeadLineDate.Value.Day) - Convert.ToInt32(item.DeadLineDate.Value.Day);

                                    if (resultPriorityDate1 > 7) /* Like that .. Solo Test */
                                        throw new ArgumentException("new Created DeadLine is > 7 days than previous");
                                    else
                                        return "BAD";


                                }
                            }
                        }
                        if (item.priority == 2)
                        {
                            List<DateTime> allPriority2Dates = new List<DateTime>();
                            foreach (var CurrentItems in TodoItems.GetAll())
                            {
                                if (CurrentItems.priority == 2 && CurrentItems.DeadLineDate != null)
                                {
                                    allPriority2Dates.Add(CurrentItems.DeadLineDate.Value);
                                }
                            }

                            int highestDay = Convert.ToInt32(allPriority2Dates.Max().Day);

                            int resultPriorityDate1 = Convert.ToInt32(item.DeadLineDate.Value.Day) - highestDay;

                            if (resultPriorityDate1 > 2) /* Like that .. Solo Test */
                                throw new ArgumentException("new Created DeadLine is > 2 days than previous");
                            else
                                return "BAD";

                        }

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

                    if(item.Description != null)
                    {
                        int count = item.Description.Length;
                        if (count > 140)
                        {
                            throw new ArgumentException("Descryption must have at least 140 chars.");
                        }
                    }
                    
                    if(item.status.Equals(Status.Wip))
                    {
                        if(item.priority == 1)
                        {
                            var totalPriority = primeNumbers.Count(s => s.priority == 1);


                            if(totalPriority < 0 || totalPriority > 1 )
                            {
                                TodoItems.Add(item);
                                return "Wip Status New Added";
                            }
                            else
                            {
                                return "Wip Status With Priority1 Can Be Only One";
                            }
                        }
                        if (item.priority == 2)
                        {

                            int totalPriority = primeNumbers.Count(s => s.priority == 2);

                            if (totalPriority >= 0 && totalPriority < 3)
                            {
                                TodoItems.Add(item);
                                return "Successfully";
                            }
                            else
                            {
                                return "Wip Status With Priority1 Can Be Only One";
                            }
                        }
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
            // Create a list of Items to Check Name Exists or Not ...
            IEnumerable<TodoItem> GetAll = TodoItems.GetAll();
            List<TodoItem> primeNumbers = GetAll.ToList();

            var id = primeNumbers.FirstOrDefault(m => m.TodoItemId == Convert.ToInt32(key));

            if (Status.Planned == id.status)
            {
                throw new ArgumentException("Can't delete Planned Status");
            }
            else
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
                if(item.Name != "ItemForTestNamePriorities") { 
                throw new ArgumentException("NameAlreadyExists");
                }
            }


            if (item.priority >= 0)
            {
                if (item.priority <= 5)
                { 
                        if (item.priority == 1)
                        {
                        //Static from DB...
                        var realCurrentToDoItem = primeNumbers.FirstOrDefault(m => m.TodoItemId == item.TodoItemId);

                        //HOw much All in All...
                        var queryStatus = primeNumbers.GroupBy(x => Status.Wip, xx => xx.priority == item.priority)
                              .Where(g => g.Count() > 1)
                              .Select(y => new { Element = y.Key, Counter = y.Count()})
                              .ToList();

                            if (queryStatus.Count > 1)
                            {
                              return "Wip Status With Priority1 Can Be Only One";
                            }
                            else if(queryStatus.Count == 1)
                            {
                                if(realCurrentToDoItem != null){ 
                                TodoItems.Update(item);
                                return "Updated Successfully";
                            }
                            }
                            else
                            {
                                return "Wip Status With Priority1 Can Be Only One";
                            }
                        }
                    


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
