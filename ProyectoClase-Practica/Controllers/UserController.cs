using Microsoft.AspNetCore.Mvc;
using ProyectoClase_Practica.Entities;
using ProyectoClase_Practica.Models;
using ProyectoClase_Practica.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ProyectoClase_Practica.Data.Implementations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Security.Claims;

namespace ProyectoClase_Practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (role == "Admin")
                return Ok(_userRepository.GetAll());
            return Forbid();
        }

        [HttpPost]
        public IActionResult Create(CreateAndUpdateUserDto dto)
        {
           try
            {
                _userRepository.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }


    }
    
}
