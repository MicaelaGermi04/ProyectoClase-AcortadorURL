using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProyectoClase_Practica.Models.Enum;

namespace ProyectoClase_Practica.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public List<UrlShortener> Urls { get; set; }
        public Rol Rol { get; set; } = Rol.User;
    }
}
