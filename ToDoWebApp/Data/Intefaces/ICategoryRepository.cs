using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Models;

namespace ToDoWebApp.Data.Intefaces
{
    public interface ICategoryRepository
    {
        /* uses to get all TodoITems */
        IEnumerable<Category> categories { get; }
    }
}
