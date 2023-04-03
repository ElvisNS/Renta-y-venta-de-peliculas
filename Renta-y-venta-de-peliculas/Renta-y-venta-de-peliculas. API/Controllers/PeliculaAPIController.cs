using Microsoft.AspNetCore.Mvc;
using Renta_y_venta_de_peliculas._API.Requests;
using Renta_y_venta_de_peliculas.BLL.Contract;
using Renta_y_venta_de_peliculas.BLL.Dtos.Pelicula;

namespace Renta_y_venta_de_peliculas._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaAPIController : ControllerBase
    {
        private readonly IPeliculaService peliculaService;
        public PeliculaAPIController(IPeliculaService peliculaService)
        {
            this.peliculaService = peliculaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = this.peliculaService.GetAll();

            if (result.Success)           
               return Ok(result);
            else
                 return BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.peliculaService.GetById(id);
            
            if (result.Success)
               return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("SavePelicula")]
        public IActionResult Post([FromBody] PeliculaSaveDto peliculaSaveDto)
        {        
            var result = this.peliculaService.SavePelicula(peliculaSaveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("UpdatePelicula")]
        public IActionResult Put([FromBody] PeliculaUpdateDto peliculaUpdateDto)
        {
            var result = this.peliculaService.UpdatePelicula(peliculaUpdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("RemovePelicula")]
        public IActionResult Remove([FromBody] PeliculaRemoveDto peliculaRemoveDto)
        {
            var result = this.peliculaService.RemovePelicula(peliculaRemoveDto);
            if (result.Success)

                return Ok(result);
            else
                return BadRequest(result);

        }
     
    }
}
