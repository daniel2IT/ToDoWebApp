using System.Collections.Generic;
using ToDoWebApp.Models;

namespace ToDoWebApp.Data.Intefaces
{
    public interface ICategoryRepository
    {
        /* uses to get all TodoITems */
        IEnumerable<Category> categories
        {
            get;
        }
    }
}