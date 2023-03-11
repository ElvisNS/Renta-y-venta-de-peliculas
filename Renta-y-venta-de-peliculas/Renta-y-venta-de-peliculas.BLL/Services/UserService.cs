using Microsoft.Extensions.Logging;
using Renta_y_venta_de_peliculas.BLL.Contract;
using Renta_y_venta_de_peliculas.BLL.Core;
using Renta_y_venta_de_peliculas.BLL.Dtos;
using Renta_y_venta_de_peliculas.BLL.Extensions;
using Renta_y_venta_de_peliculas.BLL.Models;
using Renta_y_venta_de_peliculas.DAL.Entities;
using Renta_y_venta_de_peliculas.DAL.Interfaces;
using Renta_y_venta_de_peliculas.DAL.Exceptions;
using System;
using System.Linq;

namespace Renta_y_venta_de_peliculas.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserService> logger;

        public UserService(IUserRepository userRepository, ILogger<UserService>logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando los usuarios");
                var user = this.userRepository.GetEntities().
                    Select(us => new UserModel()
                    {
                        cod_usuario = us.cod_usuario,
                        txt_user = us.txt_user,
                        txt_password = us.txt_password,
                        txt_nombre = us.txt_nombre,
                        txt_apellido = us.txt_apellido,
                        nro_doc = us.nro_doc,
                        sn_activo = us.sn_activo,
                        cod_rol = us.cod_rol,
                        CreationDate = us.CreationDate
                    }).ToList();

                result.Data = user;

                result.Message = "se consultaron los usuarios";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error extragendo los usuarios";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando el usuario");

                var user = this.userRepository.GetEntity(Id);

                UserModel userModel = new UserModel()
                {
                    cod_usuario = user.cod_usuario,
                    txt_user = user.txt_user,
                    txt_password = user.txt_password,
                    txt_nombre = user.txt_nombre,
                    txt_apellido = user.txt_apellido,
                    nro_doc = user.nro_doc,
                    sn_activo = user.sn_activo,
                    cod_rol = user.cod_rol,
                    CreationDate = user.CreationDate
                };

                result.Data = userModel;

                result.Message = "se consulto el usuario";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error extragendo el usuario";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveUser(UserRemoveDto userRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {

                DAL.Entities.User user = this.userRepository.GetEntity(userRemoveDto.cod_usuario);

                user.cod_usuario = userRemoveDto.cod_usuario;
                user.DeletedDate = userRemoveDto.DeletedDate;
                user.Deleted = true;
                user.UserDeleted = userRemoveDto.UserDeleted;
                
                this.userRepository.Update(user);

                this.userRepository.SaveChanges();

                result.Message = "el usuario se ha removido correctamente";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error removiendo el usuario";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveUser(UserAddDto userAddDto)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(userAddDto.txt_nombre))
            {
                result.Success = false;
                result.Message = "El nombre es requerido";
                return result;
            }
            if (userAddDto.txt_nombre.Length > 50)
            {
                result.Success = false;
                result.Message = "La logitud del nombre es inválida";
                return result;
            }
            if (string.IsNullOrEmpty(userAddDto.txt_apellido))
            {
                result.Success = false;
                result.Message = "El apellido es requerido";
                return result;
            }
            if (userAddDto.txt_apellido.Length > 50)
            {
                result.Success = false;
                result.Message = "La logitud del apellido es inválida";
                return result;
            }
            if (string.IsNullOrEmpty(userAddDto.nro_doc))
            {
                result.Success = false;
                result.Message = "El numero cod es requerido";
                return result;
            }
            if (userAddDto.nro_doc.Length > 50)
            {
                result.Success = false;
                result.Message = "La logitud del numero cod es inválida";
                return result;
            }
            try
            {
                this.logger.LogInformation("Guardando  el usuario");

                User user = userAddDto.GetUserEntityFromDtoSave();

                this.userRepository.Save(user);

                this.userRepository.SaveChanges();

                result.Message = "el usuario se ha guardado correctamente";
            }
            catch (UserDataExceptions uex)
            {
                result.Message = uex.Message;
                result.Success = false;
                this.logger.LogError(result.Message, uex.ToString());
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el usuario";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateUser(UserUpdateDto userUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (string.IsNullOrEmpty(userUpdateDto.txt_nombre))
                {
                    result.Success = false;
                    result.Message = "El nombre es requerido";
                    return result;
                }
                if (userUpdateDto.txt_nombre.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La logitud del nombre es inválida";
                    return result;
                }
                if (string.IsNullOrEmpty(userUpdateDto.txt_apellido))
                {
                    result.Success = false;
                    result.Message = "El apellido es requerido";
                    return result;
                }
                if (userUpdateDto.txt_apellido.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La logitud del apellido es inválida";
                    return result;
                }
                if (string.IsNullOrEmpty(userUpdateDto.nro_doc))
                {
                    result.Success = false;
                    result.Message = "El numero cod es requerido";
                    return result;
                }
                if (userUpdateDto.nro_doc.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La logitud del numero cod es inválida";
                    return result;
                }
                this.logger.LogInformation("Modificando  el usuario");

                User user = this.userRepository.GetEntity(userUpdateDto.cod_usuario);

                user.cod_usuario = userUpdateDto.cod_usuario;
                user.txt_user = userUpdateDto.txt_user;
                user.txt_password = userUpdateDto.txt_password;
                user.txt_nombre = userUpdateDto.txt_nombre;
                user.txt_apellido = userUpdateDto.txt_apellido;
                user.nro_doc = userUpdateDto.nro_doc;
                user.sn_activo = userUpdateDto.sn_activo;
                user.cod_rol = userUpdateDto.cod_rol;
                user.UserMod = userUpdateDto.UserMod;
                user.ModifyDate = userUpdateDto.ModifyDate;

                this.userRepository.Update(user);

                this.userRepository.SaveChanges();

                result.Message = "el usuario se ha modificado correctamente";
            }
            catch (UserDataExceptions uex)
            {
                result.Message = uex.Message;
                result.Success = false;
                this.logger.LogError(result.Message, uex.ToString());
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error modificando el usuario";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
