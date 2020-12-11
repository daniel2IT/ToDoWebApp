using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApp.Models;

namespace ToDoWebApp.Data
{
    public class ToDoContext : DbContext
    {
        /* Db konfikuracija(sirdis...mappingas..) */
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }
        
/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }*/


        /* Lentele ..*/
        public DbSet<Category> Categories { get; set; }



    }
}
