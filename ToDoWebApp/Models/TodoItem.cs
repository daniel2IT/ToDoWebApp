using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Models
{
    public class TodoItem
    {

        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }

        private int[] totalPriority;

        public int[] priority {
                                get { return totalPriority; }
                                set{
                                        totalPriority = new int[5] { 1, 2, 3, 4, 5 };
                                   }
                               }

    }
}
