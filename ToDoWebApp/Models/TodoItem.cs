using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebApp.Models
{
    public class TodoItem
    {

        int Id;
        string Name;
        string Description;

        int[] priority = new int[5] { 1, 2, 3, 4, 5 };

    }
}
