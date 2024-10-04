using Microsoft.AspNetCore.Mvc;
using Practica_04.Models;
using Practica_04.Repositories;
using Practica_04.Repositories.Repositories_S;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practica_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {

        private  ITurnosRepository _turnosRepository;
        private IServicioRepository _servicioRepository;

        // GET: api/<AppController>
        [HttpGet]
        public IActionResult GetServicios()
        {
            try
            {
                return Ok(_servicioRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error, intentelo de nuevo!");
            }
        }

        // GET api/<AppController>/5
        [HttpGet("{id}")]
        public IActionResult GetTurnos(int id)
        {
            try
            {
                return Ok(_turnosRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error, intentelo de nuevo!");
            }
        }

        // POST api/<AppController>
        [HttpPost]
        public IActionResult Post([FromBody] TTurno turno)
        {
            try
            {
                if (IsValid(turno))
                {
                    _turnosRepository.Create(turno);
                    return Ok("Turno registrado correctamente!");
                }
                else
                {
                    return BadRequest("Debe completar los campos para obtener el turno!");
                }  
            }
            catch (Exception)
            {

                return StatusCode(500, "Ha ocurrido un error, intentelo de nuevo!");
            }
        }

        private bool IsValid(TTurno turno)
        {
            return !string.IsNullOrEmpty(turno.Cliente) && !string.IsNullOrEmpty(turno.Fecha) && !string.IsNullOrEmpty(turno.Hora);
        }

        // PUT api/<AppController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            try
            {
                if (_turnosRepository.Update(id))
                {
                    return Ok("Turno cancelado!");
                }
                else
                {
                    return NotFound("Turno no encontrado!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error, intentelo de nuevo!");
            }
        }

        // DELETE api/<AppController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
