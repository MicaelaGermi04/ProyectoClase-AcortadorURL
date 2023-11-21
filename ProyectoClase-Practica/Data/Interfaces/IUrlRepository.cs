using ProyectoClase_Practica.Entities;

namespace ProyectoClase_Practica.Data.Interfaces
{
    public interface IUrlRepository
    {
        UrlShortener GetUrlById(int id);
        UrlShortener GetUrlByShortUrl(string shortUrl);
        void AddUrl(UrlShortener url);
        void VisitorCounter(int id);
    }
};
