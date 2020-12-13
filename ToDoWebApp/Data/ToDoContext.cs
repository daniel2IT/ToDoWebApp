using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ToDoWebApp.Data
{
    public class ToDoContext : DbContext
    {
        /* Lentele ..*/
        public DbSet<TodoItem> TodoItem { get; set; }
        public DbSet<Category> Categories { get; set; }
  
        /* Db konfikuracija(sirdis...mappingas..) */
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        /* Lentele ..*/
    }
}
