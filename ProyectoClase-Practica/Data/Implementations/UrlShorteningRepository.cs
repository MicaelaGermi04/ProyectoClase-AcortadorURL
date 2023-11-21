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
            _context.SaveChanges();
        }
        public void VisitorCounter(int id)
        {
            var url= _context.Urls.FirstOrDefault(u => u.Id == id);
            if (url != null)
            {
                url.Visit++;
                _context.SaveChanges();
            }
        }
    }
};
