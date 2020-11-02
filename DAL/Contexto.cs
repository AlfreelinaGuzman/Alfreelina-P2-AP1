using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
//using Alfreelina_P2_AP1.Entidades;


namespace Alfreelina_P2_AP1.DAL{

    public class Contexto : DbContext{
        

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source= DATA/datbase.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

 }   
}