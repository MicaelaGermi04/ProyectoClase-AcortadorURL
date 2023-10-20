using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoClase_Practica.Entities
{
    public class UrlShortener
    { 
        public int Id { get; set; }
     
        public string LongUrl { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;
        
    }
}
