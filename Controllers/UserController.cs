using BackendFinalGrupo10.DTOs;
using BackendFinalGrupo10.Entitys;
using BackendFinalGrupo10.Repository;
using BackendFinalGrupo10.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace BackendFinalGrupo10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private string roleRut = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
        private readonly IUserRepository _userRepository;
        

        public UserController(IUserRepository userRepository)
        {

            _userRepository = userRepository; 

        }

        //Devuelve una Claim
        private string? GetClaim(string type)
        {
            return User.Claims.FirstOrDefault(c => c.Type == type)?.Value;
        }

 
        [HttpGet]

        public IActionResult GetAll()
        {

            if (GetClaim(roleRut) == "admin") return Ok(_userRepository.GetAll());

            return Unauthorized("Solo Administradores");

        }

        [HttpGet]
        [Route("{id}")]

        public IActionResult GetOneById(int id)
        {
            
            //Usuarios comunes, solo obtienen sus propios datos.
            if (GetClaim(roleRut) != "admin")
            {
                id = Int32.TryParse(GetClaim("userId"), out var valId) ? valId : (int)-1;
            }
      

            try
            {
                return Ok(_userRepository.GetAll().Where(u => u.Id == id));
            }
            catch
            {
                return NotFound();
            }

        }


        [HttpPost]

        public IActionResult CreateUser(User user) //(CreateAndUpdateUserDTO createDto)
        {
            try
            {
                _userRepository.Create(user);
                return Created("Created", user);
            }
            catch (Exception exeption)
            {
                return BadRequest(exeption.Message);
            }

        }

        [HttpPut]
        [Route("{password}")]
        public IActionResult UpdateUser(User user, string password)
        {
            int usser = Int32.TryParse(GetClaim("userId"), out var validate) ? validate : (int)0;

            ////Si es user, usamos su ID, si es admin, ya paso el ID
            if (GetClaim(roleRut) != "admin") user.Id = usser;

            //if (_userRepository.GetAll().Where(c => c.Password == password && c.Id == usser) == null)
            //{
            //    return BadRequest();
            //}

            try
            {
                _userRepository.Update(user);
            }
            catch (Exception exeption)
            {
                return BadRequest(exeption.Message);
            }

            return Ok();
        }


        [HttpDelete]
        
        public IActionResult DeleteUser(DeleteDto user)
        {

            int usser = Int32.TryParse(GetClaim("userId"), out var validate) ? validate : (int)0;

            //Si es user, usamos su ID, si es admin, ya paso el ID a borrar
            if (GetClaim(roleRut) != "admin") user.Id = usser;

            //if (_userRepository.GetAll().Where(c => c.Password == user.Password && c.Id == usser) == null)
            //{
            //    return BadRequest();
            //}

            try
            {
                _userRepository.Delete(user.Id);
            }
            catch (Exception exeption)
            {
                return BadRequest(exeption.Message);
            }

            return Ok();
        }
    }
}
