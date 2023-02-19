using Microsoft.AspNetCore.Mvc;
using Renta_y_venta_de_pelicula.API.Requests;
using Renta_y_venta_de_peliculas.DAL.Entities;
using Renta_y_venta_de_peliculas.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace Renta_y_venta_de_pelicula.API.Controllers
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

        
        [HttpGet("id")]
        public IActionResult Get(int Id)
        {
            var user = this.userRepository.GetById(Id);
            return Ok(user);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] UserAddRequest userAdd)
        {
            User iuser = new User()
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
            this.userRepository.Save(iuser);
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Put(int Id,[FromBody] UserUpdateRequest userUpdate)
        {
            User useirUpdate = this.userRepository.GetById(Id);
            useirUpdate.cod_usuario = userUpdate.cod_usuario;
            useirUpdate.txt_nombre = userUpdate.txt_nombre;
            useirUpdate.txt_apellido = userUpdate.txt_apellido;
            useirUpdate.txt_user = userUpdate.txt_user;
            useirUpdate.txt_password = userUpdate.txt_password;
            useirUpdate.cod_rol = userUpdate.cod_rol;
            useirUpdate.nro_doc = userUpdate.nro_doc;
            useirUpdate.sn_activo = userUpdate.sn_activo;
            useirUpdate.ModifyDate = DateTime.Now;
            useirUpdate.UserMod = userUpdate.UserMod;

            this.userRepository.Update(useirUpdate);
            return Ok();
        }

        [HttpDelete("Remove")]
        public IActionResult Remove(int Id, UserRemoveRequest userRemove)
        {
            User useirRemove = this.userRepository.GetById(Id);
            useirRemove.DeletedDate = DateTime.Now;
            useirRemove.UserDeleted = userRemove.UserDeleted;
            useirRemove.Deleted = true;
            this.userRepository.Remove(useirRemove);
            return Ok();
        }
    }
}
