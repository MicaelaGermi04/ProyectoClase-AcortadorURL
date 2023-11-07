using System.ComponentModel.DataAnnotations;

namespace ProyectoClase_Practica.Models.Dto
{
    public class UrlForCreations
    {
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
