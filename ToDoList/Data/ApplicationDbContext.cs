﻿using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Entities;

namespace ToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }
    }
}
