using BackendFinalGrupo10.DTOs;
using BackendFinalGrupo10.Entitys;
using BackendFinalGrupo10.Repository;
using BackendFinalGrupo10.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendFinalGrupo10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            return Ok(_userRepository.GetAll());

        }

        [HttpGet]
        [Route("{id}")]

        public IActionResult GetOneById(int id)
        {
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

        public IActionResult CreateUser(CreateAndUpdateUserDTO createDto)
        {
            try
            {
                _userRepository.Create(createDto);
            }
            catch (Exception exeption)
            {
                return BadRequest(exeption.Message);
            }

            return Created("Created", createDto);
        }

        [HttpPut]
        [Route("{Id}")]

        public IActionResult UpdateUser(CreateAndUpdateUserDTO updateDto, int id)
        {
            try
            {
                _userRepository.Update(updateDto, id);
            }
            catch (Exception exeption)
            {
                return BadRequest(exeption.Message);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{Id}")]

        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userRepository.Delete(id);
            }
            catch (Exception exeption)
            {
                return BadRequest(exeption.Message);
            }

            return Ok();
        }
    }
}
