using System.ComponentModel.DataAnnotations;

namespace ProyectoClase_Practica.Models
{
    public class UrlForCreations
    { 
        [Required]
        public string OriginalUrl { get; set; } = string.Empty; //Valor vacion por defecto
    }
}
