using Microsoft.EntityFrameworkCore;
using ProyectoClase_Practica.Data;
using System.Globalization;
using System;
using ProyectoClase_Practica.Data.Interfaces;
using ProyectoClase_Practica.Entities;

namespace ProyectoClase_Practica.Data.Implementations
{
    public class UrlShorteningRepository : IUrlRepository
    {

        private readonly UrlShortenerContext _context;
        public UrlShorteningRepository(UrlShortenerContext context)
        {
            _context = context;
        }
        public UrlShortener GetUrlById(int id)
        {
            return _context.Urls.FirstOrDefault(u => u.Id == id);
        }
        public UrlShortener GetUrlByShortUrl(string shortUrl)
        {
            return _context.Urls.FirstOrDefault(u => u.ShortUrl == shortUrl);
        }
        public void AddUrl(UrlShortener url)
        {
            _context.Urls.Add(url);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
};
