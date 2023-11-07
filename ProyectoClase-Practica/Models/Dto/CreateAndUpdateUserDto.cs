using ProyectoClase_Practica.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProyectoClase_Practica.Models
{
    public class CreateAndUpdateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

    }
}