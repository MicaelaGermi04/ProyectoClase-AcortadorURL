using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using ProyectoClase_Practica.Entities;
using System;

namespace ProyectoClase_Practica.Data
{
    public class UrlShortenerContext : DbContext //hereda
    {
        public DbSet<UrlShortener> Urls { get; set; }
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) { } //Llama al constructor de DbContext que es el que acepta las opciones

    }
}

