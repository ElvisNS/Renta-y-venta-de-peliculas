using Microsoft.AspNetCore.Mvc;
using Renta_y_venta_de_peliculas._API.Requests;
using Renta_y_venta_de_peliculas.BLL.Contract;
using Renta_y_venta_de_peliculas.BLL.Dtos.Pelicula;

namespace Renta_y_venta_de_peliculas._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService peliculaService;
        public PeliculaController(IPeliculaService peliculaService)
        {
            this.peliculaService = peliculaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = this.peliculaService.GetAll();

            if (!result.Success)
                return BadRequest(result);
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.peliculaService.GetById(id);
            return Ok(result);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] PeliculaAddRequest peliculaAdd)
        {
            PeliculaAddDto pelicula = new PeliculaAddDto()
            {
                TxtDesc = peliculaAdd.Txt_desc,
                CantDisponiblesAlquiler = peliculaAdd.Cant_disponibles_alquiler,    
                CantDisponiblesVenta = peliculaAdd.Cant_disponibles_venta,
                PrecioAlquiler = peliculaAdd.Precio_alquiler,
                PrecioVenta = peliculaAdd.Precio_venta,
                CreateDate = peliculaAdd.Create_date,
                CreateUser = peliculaAdd.Create_user
            };
           
            var result = this.peliculaService.SavePelicula(pelicula);
           
            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] PeliculaUpdateDto pelicula)
        {
            var result = this.peliculaService.UpdatePelicula(pelicula);

            return Ok(result);
        }

        [HttpPost("Remove")]
        public IActionResult Remove([FromBody] PeliculaRemoveDto pelicula)
        {
            var result = this.peliculaService.RemovePelicula(pelicula);

            return Ok(result);
        }
     
    }
}
