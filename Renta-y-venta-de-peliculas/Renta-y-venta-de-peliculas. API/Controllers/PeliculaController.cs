using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Renta_y_venta_de_peliculas.DAL.Context;
using Renta_y_venta_de_peliculas.DAL.Entities;
using Renta_y_venta_de_peliculas.DAL.Interfaces;
using Renta_y_venta_de_peliculas.DAL.Repositories;
using Renta_y_venta_de_peliculas._API.Requests;



namespace Renta_y_venta_de_peliculas._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly PeliculaRepository peliculaRepository;
        public PeliculaController(PeliculaRepository peliculaRepository)
        {
            this.peliculaRepository = peliculaRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pelicula = this.peliculaRepository.GetAll();
            return Ok(pelicula);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var pelicula = this.peliculaRepository.GetById(id);
            return Ok(pelicula);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] PeliculaAddRequest peliculaAdd )
        {
            Pelicula pelicula = new Pelicula()
            {
                txt_desc = peliculaAdd.txt_desc,
                cant_disponibles_alquiler = peliculaAdd.cant_disponibles_alquiler,
                cant_disponibles_venta = peliculaAdd.cant_disponibles_venta,
                precio_alquiler = peliculaAdd.precio_alquiler,
                precio_venta = peliculaAdd.precio_venta,
                CreationDate = DateTime.Now,
                CreationUser = peliculaAdd.CreationUser
            };
            this.peliculaRepository.Save(pelicula);
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] Pelicula pelicula)
        {
            this.peliculaRepository.Update(pelicula);
            return Ok();
        }

        [HttpPut("Remove")]
        public IActionResult Remove([FromBody] Pelicula pelicula)
        {
            this.peliculaRepository.Save(pelicula);
            return Ok();
        }
     
    }
}
