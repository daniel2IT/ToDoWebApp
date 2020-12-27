using Microsoft.EntityFrameworkCore;
using ToDoWebApp.Models;

namespace ToDoWebApp.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext()
        {

        }
        /* Lentele ..*/
        public virtual DbSet<TodoItem> TodoItem { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
  
        /* Db konfikuracija(sirdis...mappingas..) */
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }



        /* Lentele ..*/
    }
}
