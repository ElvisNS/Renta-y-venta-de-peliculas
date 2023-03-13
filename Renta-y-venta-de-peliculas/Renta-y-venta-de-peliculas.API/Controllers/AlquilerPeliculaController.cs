using System;
using Microsoft.AspNetCore.Mvc;
using Renta_y_venta_de_peliculas.BLL.Contract;
using Renta_y_venta_de_peliculas.BLL.Dtos;
using Renta_y_venta_de_peliculas.DAL.Entities;
using Renta_y_venta_de_peliculas.DAL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Renta_y_venta_de_peliculas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquilerPeliculaController : ControllerBase
    {
        private readonly IAPeliculasService aPeliculasService;

        public AlquilerPeliculaController(IAPeliculasService aPeliculasService)
        {
            this.aPeliculasService = aPeliculasService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.aPeliculasService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.aPeliculasService.GetById(id);
            return Ok(result);
        }
        [HttpPost("Save")]
        public IActionResult Post([FromBody] APelicualAddDto Alquilerpelicula)
        {
            APelicualAddDto alquilerPelicula = new APelicualAddDto()
            {
                    Id = Alquilerpelicula.Id,
                    precio = Alquilerpelicula.precio,
                    fecha = Alquilerpelicula.fecha,
                    cod_pelicula = Alquilerpelicula.cod_pelicula,
                    cod_usuario = Alquilerpelicula.cod_usuario,
                    devuelta = Alquilerpelicula.devuelta,
                    fecha_devolucion = Alquilerpelicula.fecha_devolucion,
                    cod_usuario_devolucion = Alquilerpelicula.cod_usuario_devolucion,
                    create_date = DateTime.Now,
                    create_user = Alquilerpelicula.create_user
            };

            var result = this.aPeliculasService.SaveAlquilerPelicula(alquilerPelicula);
            return Ok(result);
        }
        [HttpPost("Update")]
        public IActionResult Put([FromBody] APeliculaUpdateDto Alquilerpelicula)
        {
            var result = this.aPeliculasService.UpdateAlquilerPelicula(Alquilerpelicula);
            return Ok(result);
        }
        [HttpPost("Remove")]
        public IActionResult Remove([FromBody] APelicualRemoveDto Alquilerpelicula)
        {
            var result = this.aPeliculasService.RemoveAlquilerPelicula(Alquilerpelicula);
            return Ok(result);
        }
    }
}
