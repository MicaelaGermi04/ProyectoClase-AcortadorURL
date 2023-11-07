using Microsoft.EntityFrameworkCore;
using ProyectoClase_Practica.Data.Interfaces;
using ProyectoClase_Practica.Entities;
using ProyectoClase_Practica.Models;
using ProyectoClase_Practica.Models.Dto;
using ProyectoClase_Practica.Models.Enum;

namespace ProyectoClase_Practica.Data.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UrlShortenerContext _context;
        public UserRepository(UrlShortenerContext context)
        {
            _context = context;
        }

        public void Create(CreateAndUpdateUserDto dto)
        {
            User newUser = new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                UserName = dto.UserName,
                Rol = Rol.User,
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == authRequestBody.Username && p.Password == authRequestBody.Password);
        }

        public List<User> GetAll() 
        {
           return _context.Users.ToList();
        }


    }
}
