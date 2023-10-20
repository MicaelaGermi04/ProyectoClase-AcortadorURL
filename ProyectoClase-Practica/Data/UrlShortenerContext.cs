//using ProyectoClase_Practica.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using ProyectoClase_Practica.Entities;
using ProyectoClase_Practica.Services;

namespace ProyectoClase_Practica.Data
{

    public class UrlShortenerContext : DbContext //hereda
    { 
        public UrlShortenerContext(DbContextOptions options) : base(options)
        { }
        public DbSet<UrlShortener> Urls { get; set; } //Dbset--> objeto de DbContext, hace del objeto una tabla.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrlShortener>(builder =>
            {
                builder.Property(s => s.Code).HasMaxLength(UrlShorteningService.NumberOfCharsInShortUrl);
                // Builder property selecciona la propiedad del codigo y tiene una longuitud maxima de 6
                builder.HasIndex(s => s.Code).IsUnique();
                //Indice en la propiedad del codigo url acortado, y este es unico 
            });
        }

    }
}

