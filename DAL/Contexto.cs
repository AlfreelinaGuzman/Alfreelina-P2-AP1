using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Alfreelina_P2_AP1.Entidades;


namespace Alfreelina_P2_AP1.DAL{

    public class Contexto : DbContext{
        
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<Tareas> Tareas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source= DATA/Proyecto.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tareas>().HasData(new Tareas{TareaID = 1, TipoTarea = "Diseño"});
        modelBuilder.Entity<Tareas>().HasData(new Tareas{TareaID = 2, TipoTarea = "Prueba"});
        modelBuilder.Entity<Tareas>().HasData(new Tareas{TareaID = 3, TipoTarea = "Analisis"});
        modelBuilder.Entity<Tareas>().HasData(new Tareas{TareaID = 4, TipoTarea = "Programacion"});
    }

 }   
}