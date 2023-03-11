using Microsoft.AspNetCore.Mvc;
using Renta_y_venta_de_pelicula.API.Requests;
using Renta_y_venta_de_peliculas.BLL.Contract;
using Renta_y_venta_de_peliculas.BLL.Dtos;
using System;

namespace Renta_y_venta_de_pelicula.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.userService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult Get(int Id)
        {
            var result = this.userService.GetById(Id);
            return Ok(result);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] UserAddRequest userAdd)
        {
            UserAddDto UserAddDto = new UserAddDto()
            {
                CreationUser = userAdd.CreationUser,
                CreationDate = DateTime.Now,
                txt_nombre = userAdd.txt_nombre,
                txt_apellido = userAdd.txt_apellido,
                txt_user = userAdd.txt_user,
                txt_password = userAdd.txt_password,
                cod_rol = userAdd.cod_rol,
                nro_doc = userAdd.nro_doc,
                sn_activo = userAdd.sn_activo
            };
            var result = this.userService.SaveUser(UserAddDto);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Put(int Id,[FromBody] UserUpdateRequest userUpdate)
        {
            UserUpdateDto userUpdateDto = new UserUpdateDto()
            {
                cod_usuario = userUpdate.cod_usuario,
                txt_nombre = userUpdate.txt_nombre,
                txt_apellido = userUpdate.txt_apellido,
                txt_user = userUpdate.txt_user,
                txt_password = userUpdate.txt_password,
                cod_rol = userUpdate.cod_rol,
                nro_doc = userUpdate.nro_doc,
                sn_activo = userUpdate.sn_activo,
                ModifyDate = DateTime.Now,
                UserMod = userUpdate.UserMod
            };
            
            var result = this.userService.UpdateUser(userUpdateDto);
            return Ok(result);

        }

        [HttpDelete("Remove")]
        public IActionResult Remove(int Id, UserRemoveRequest userRemove)
        {
            UserRemoveDto userRemoveDto  = new UserRemoveDto()
            {
                cod_usuario = userRemove.cod_usuario,
                DeletedDate = DateTime.Now,
                UserDeleted = userRemove.UserDeleted,
                Deleted = true
            };
            var result = this.userService.RemoveUser(userRemoveDto);
            return Ok(result);
        }
    }
}
