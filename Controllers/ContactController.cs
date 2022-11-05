using BackendFinalGrupo10.DTOs;
using BackendFinalGrupo10.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendFinalGrupo10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ContactController : ControllerBase
    {

        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository; 
        }



        [HttpGet]

        public IActionResult GetAll()
        {
            
            return Ok(_contactRepository.GetAll());
        }

        [HttpGet]
        [Route("{id}")]

        public IActionResult GetOneById(int id)
        {
            try
            {
                return Ok(_contactRepository.GetAll().Where(c => c.Id == id));
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpPost]

        public IActionResult CreateContact(CreateAndUpdateContactDTO createDto)
        {
            try
            {
                _contactRepository.Create(createDto);
            }
            catch(Exception exeption)
            {
                return BadRequest(exeption.Message);
            }

            return Created("Created", createDto);
        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult UpdateContact(CreateAndUpdateContactDTO updateDto, int id)
        {
            try
            {
                _contactRepository.Update(updateDto, id);
            }
            catch (Exception exeption)
            {
                return BadRequest(exeption.Message);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{Id}")]

        public IActionResult DeleteContact(int id)
        {
            try
            {
                _contactRepository.Delete(id);
            }
            catch (Exception exeption)
            {
                return BadRequest(exeption.Message);
            }

            return Ok();
        }
    }
}
