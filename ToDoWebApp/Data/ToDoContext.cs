﻿using Microsoft.EntityFrameworkCore;
using ToDoWebApp.Models;

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
