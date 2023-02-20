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
        private readonly IPeliculaRepository peliculaRepository;
        public PeliculaController(IPeliculaRepository peliculaRepository)
        {
            this.peliculaRepository = peliculaRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var peliculas = this.peliculaRepository.GetAll();
            return Ok(peliculas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pelicula = this.peliculaRepository.GetById(id);
            return Ok(pelicula);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] PeliculaAddRequest peliculaAdd)
        {
            Pelicula pelicula = new Pelicula()
            {
                Txt_desc = peliculaAdd.Txt_desc,
                Cant_disponibles_alquiler = peliculaAdd.Cant_disponibles_alquiler,
                Cant_disponibles_venta = peliculaAdd.Cant_disponibles_venta,
                Precio_alquiler = peliculaAdd.Precio_alquiler,
                Precio_venta = peliculaAdd.Precio_venta,
                Create_date = peliculaAdd.Create_date,
                Create_user = peliculaAdd.Create_user
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
