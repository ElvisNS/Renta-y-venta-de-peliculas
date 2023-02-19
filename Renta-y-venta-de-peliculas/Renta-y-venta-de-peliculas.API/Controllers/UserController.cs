using Microsoft.AspNetCore.Mvc;
using Renta_y_venta_de_peliculas.API.Requets;
using Renta_y_venta_de_peliculas.DAL.Entities;
using Renta_y_venta_de_peliculas.DAL.Interfaces;

namespace Renta_y_venta_de_peliculas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var user = this.userRepository.GetAll();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = this.userRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] UserAddRequest userAdd)
        {
            User user = new User()
            {
                CreationUser = userAdd.CreateUser,
                CreationDate = userAdd.CreateDate,
                txt_nombre = userAdd.txt_nombre,
                txt_apellido = userAdd.txt_apellido,
                txt_user = userAdd.txt_user,
                txt_password = userAdd.txt_password,
                cod_rol = userAdd.cod_rol,
                nro_doc = userAdd.nro_doc,
                sn_activo = userAdd.sn_activo
            };
            this.userRepository.Save(user);
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Put([FromBody] User user)
        {
            this.userRepository.Update(user);
            return Ok();
        }

        [HttpDelete("Remove")]
        public IActionResult Remove(User user)
        {
            this.userRepository.Remove(user);
            return Ok();
        }
    }
}
