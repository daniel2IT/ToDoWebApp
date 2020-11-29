using System.Collections.Generic;
using ToDoWebApp.Data.Intefaces;
using ToDoWebApp.Models;

namespace ToDoWebApp.DataProviders
{
    public class CategoryProvider : ICategoryRepository
    {

        public IEnumerable<Category> categories
        {
            get
            {
                return new List<Category> {

          new Category {
            CategoryId = 1,
            Name = "Item",

          },
          new Category {
            CategoryId = 2,
            Name = "Item1",

          },
          new Category {
            CategoryId = 3,
            Name = "Item2",

          },
          new Category {
            CategoryId = 4,
            Name = "Item3",

          },
          new Category {
            CategoryId = 5,
            Name = "Item4",

          }
        };
            }
        }
    }
}