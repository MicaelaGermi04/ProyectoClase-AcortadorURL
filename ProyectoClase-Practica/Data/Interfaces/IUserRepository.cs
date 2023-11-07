using ProyectoClase_Practica.Models;
using ProyectoClase_Practica.Entities;
using ProyectoClase_Practica.Models.Dto;

namespace ProyectoClase_Practica.Data.Interfaces
{
    public interface IUserRepository
    {
        void Create(CreateAndUpdateUserDto dto);
        List<User> GetAll();
        User? ValidateUser(AuthenticationRequestBody authRequestBody);

    }
}
