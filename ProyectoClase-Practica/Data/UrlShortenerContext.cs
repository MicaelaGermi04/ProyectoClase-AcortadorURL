using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using ProyectoClase_Practica.Entities;
using System;
using static System.Net.WebRequestMethods;

namespace ProyectoClase_Practica.Data
{
    public class UrlShortenerContext : DbContext //hereda
    {
        public DbSet<UrlShortener> Urls { get; set; }
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) { } //Llama al constructor de DbContext que es el que acepta las opciones

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UrlShortener url1 = new UrlShortener()
            {
                Id = 1,
                LongUrl = "https://www.youtube.com/watch?v=8cKvvmPwgP4&list=RD8cKvvmPwgP4&start_radio=1&ab_channel=ElCanserbero",
                ShortUrl = "g9Kr21",
                CategoryId = 1,

            };
            UrlShortener url2 = new UrlShortener()
            {
                Id = 2,
                LongUrl = "https://www.youtube.com/watch?v=v_zZmsFZDaM&list=RD8cKvvmPwgP4&index=2&ab_channel=elvecindariocalle13",
                ShortUrl = "jrE43Ps",
                CategoryId = 1,

            };
            UrlShortener url3 = new UrlShortener()
            {
                Id = 3,
                LongUrl = "https://www.youtube.com/watch?v=8SOr5IEAxbc&ab_channel=PeloMusicGroup",
                ShortUrl = "4fOd9S",
                CategoryId= 2,

            };
            Category Categoria1=new Category()
            {
                Id = 1,
                Name = "Categoria 1"
            };
            Category Categoria2=new Category()
            {
                Id = 2,
                Name = "Categoria 2"
            };
            Category Categoria3=new Category()
            {
                Id = 3,
                Name = "Categoria 3"
            };
            modelBuilder.Entity<Category>().HasData(
                Categoria1, Categoria2, Categoria3);
            modelBuilder.Entity<UrlShortener>().HasData(
                url1, url2, url3);
            base.OnModelCreating(modelBuilder);
        }
    }
}

