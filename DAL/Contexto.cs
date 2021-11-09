using Microsoft.EntityFrameworkCore;
using P2_AP1_Felix_20180570.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Felix_20180570.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<TiposTareas> TiposTareas { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\BDProyectos.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposTareas>().HasData(new TiposTareas
            {
                TipoTareaID = 1,
                TipoTarea = "Analisis",
            });

            modelBuilder.Entity<TiposTareas>().HasData(new TiposTareas
            {
                TipoTareaID = 2,
                TipoTarea = "Diseño",
            });

            modelBuilder.Entity<TiposTareas>().HasData(new TiposTareas
            {
                TipoTareaID = 3,
                TipoTarea = "Programacion",
            });

            modelBuilder.Entity<TiposTareas>().HasData(new TiposTareas
            {
                TipoTareaID = 4,
                TipoTarea = "Prueba",
            });
        }

    }
}
