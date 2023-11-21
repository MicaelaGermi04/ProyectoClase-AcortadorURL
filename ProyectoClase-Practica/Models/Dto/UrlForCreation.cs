using System.ComponentModel.DataAnnotations;

namespace ProyectoClase_Practica.Models.Dto
{
    public class UrlForCreations
    { 
        public string LongUrl { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
