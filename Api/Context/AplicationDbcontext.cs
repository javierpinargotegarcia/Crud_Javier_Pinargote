using Api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Api.Context
{
    public class AplicationDbcontext : IdentityDbContext
    {
        public AplicationDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tareas> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tareas>(tb =>
            {
                tb.HasKey(t => t.ID);
                tb.Property(t => t.Titulo);
                tb.Property(t => t.Descripcion).IsRequired();
                tb.Property(t => t.FechaCreacion).IsRequired();
                tb.Property(t => t.FechaVencimiento).IsRequired();
                tb.Property(t => t.Completada).IsRequired();
                tb.Property(t => t.Prioridad).IsRequired();
                tb.Property(t => t.Etiqueta).IsRequired();
                tb.ToTable("Tareas");
            });
        }

    }
}
