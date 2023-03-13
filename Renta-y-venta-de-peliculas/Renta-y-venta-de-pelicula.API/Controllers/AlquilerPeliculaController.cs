using Microsoft.AspNetCore.Mvc;
using Renta_y_venta_de_pelicula.API.Requests;
using Renta_y_venta_de_peliculas.DAL.Entities;
using Renta_y_venta_de_peliculas.DAL.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Renta_y_venta_de_pelicula.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquilerPeliculaController : ControllerBase
    {
        private readonly IAlquilerPeliculasRepository alquilerPeliculasRepository;

        public AlquilerPeliculaController(IAlquilerPeliculasRepository alquilerPeliculasRepository)
        {
            this.alquilerPeliculasRepository = alquilerPeliculasRepository;
        }
        // GET: api/<AlquilerPeliculaController>
        [HttpGet]
        public IActionResult Get()
        {
            var alquilerpelicula = this.alquilerPeliculasRepository.GetAll();
            return Ok(alquilerpelicula);
        }

        // GET api/<AlquilerPeliculaController>/5
        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var alquilerPelicula = this.alquilerPeliculasRepository.GetById(id);
            return Ok(alquilerPelicula);
        }

        // POST api/<AlquilerPeliculaController>
        [HttpPost("Save")]
        public IActionResult Post([FromBody] AlquilerPeliculaAddRequest alquilerPeliculaAddRequest)
        {
            AlquilerPelicula AlquilerPeliculaToAdd = new AlquilerPelicula()
            {
                cod_pelicula = alquilerPeliculaAddRequest.cod_pelicula,
                cod_usuario = alquilerPeliculaAddRequest.cod_usuario,
                precio = alquilerPeliculaAddRequest.precio,
                fecha = DateTime.Now,
                devuelta = alquilerPeliculaAddRequest.devuelta,
                fecha_devolucion = alquilerPeliculaAddRequest.fecha_devolucion,
                cod_usuario_devolucion = alquilerPeliculaAddRequest.cod_usuario_devolucion,
                create_user = alquilerPeliculaAddRequest.create_user,
                create_date = DateTime.Now,
            };
            this.alquilerPeliculasRepository.Save(AlquilerPeliculaToAdd);
            return Ok();
        }

        // PUT api/<AlquilerPeliculaController>/5
        [HttpPut("Update")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<AlquilerPeliculaController>/5
        [HttpDelete("Remove")]
        public IActionResult Remove(int id)
        {
            return Ok();
        }
    }
}
