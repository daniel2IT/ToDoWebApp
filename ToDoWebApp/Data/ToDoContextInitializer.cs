using System.Linq;
using ToDoWebApp.Models;

namespace ToDoWebApp.Data
{
    public static class ToDoContextInitializer
    {
        public static void Initialize(ToDoContext context)
        {
            context.Database.EnsureCreated();

            var courses = new Category[]
          {
            new Category{Name="Chemistry"},
            new Category{Name="Microeconomics"},
            new Category{Name="Macroeconomics"},
            new Category{Name="Calculus"},
            new Category{Name="Trigonometry"},
            new Category{Name="Composition"},
            new Category{Name="Literature"}
          };
            foreach (Category c in courses)
            {

                if (context.Categories.Any(x => x.Name == c.Name))
                {
                }
                else
                {
                    context.Categories.Add(c);
                }
            }
            context.SaveChanges();
        }
    }
}
