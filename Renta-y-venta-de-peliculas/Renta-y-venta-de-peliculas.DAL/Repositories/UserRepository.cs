using Microsoft.Extensions.Logging;
using Renta_y_venta_de_peliculas.DAL.Context;
using Renta_y_venta_de_peliculas.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Renta_y_venta_de_peliculas.DAL.Repositories
{
    public class UserRepository : Interfaces.IUserRepository
    {
        private readonly RYPContext rYPContext;
        private readonly ILogger<UserRepository> iloger;

        public UserRepository(RYPContext rYPContext, ILogger<UserRepository> iloger)
        {
            this.rYPContext = rYPContext;
            this.iloger = iloger;
        }
        public bool Exists(string name)
        {
            return this.rYPContext.user.Any(sp => sp.txt_nombre == name);
        }

        public List<User> GetAll()
        {
            return this.rYPContext.user.Where(us => !us.Deleted).ToList();
        }

        public User GetById(int userId)
        {
            return this.rYPContext.user.Find(userId);
        }

        public void Remove(User user)
        {
            try
            {
                User userToRemove = this.GetById(user.cod_usuario);
                userToRemove.DeletedDate = DateTime.Now;
                userToRemove.UserDeleted = user.UserDeleted;
                userToRemove.Deleted = true;

                this.rYPContext.user.Update(userToRemove);
                this.rYPContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this.iloger.LogError($"Error removiendo el usuario {ex.Message} ", ex.ToString());
            }
        }

        public void Save(User user)
        {
            try
            {
                User userToAdd = new User()
                {
                    CreationUser = user.CreationUser,
                    CreationDate = DateTime.Now,
                    txt_nombre = user.txt_nombre,
                    txt_apellido = user.txt_apellido,
                    txt_user = user.txt_user,
                    txt_password = user.txt_password,
                    cod_rol = user.cod_rol,
                    nro_doc = user.nro_doc,
                    sn_activo = user.sn_activo
                };
                this.rYPContext.user.Add(userToAdd);
                this.rYPContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this.iloger.LogError($"Error guardando el usuario {ex.Message} ", ex.ToString());
            }
        }

        public void Update(User user)
        {
            try
            {
                User userToUpdate = this.GetById(user.cod_usuario);
                userToUpdate.cod_usuario = user.cod_usuario;
                userToUpdate.txt_nombre = user.txt_nombre;
                userToUpdate.txt_apellido = user.txt_apellido;
                userToUpdate.txt_user = user.txt_user;
                userToUpdate.txt_password = user.txt_password;
                userToUpdate.cod_rol = user.cod_rol;
                userToUpdate.nro_doc = user.nro_doc;
                userToUpdate.sn_activo = user.sn_activo;
                userToUpdate.ModifyDate = DateTime.Now;
                userToUpdate.UserMod = user.UserMod;

                this.rYPContext.user.Update(userToUpdate);
                this.rYPContext.SaveChanges();
            }
            catch (Exception ex)
            {

                this.iloger.LogError($"Error modificando el usuario {ex.Message} ", ex.ToString());
            }
        }
    }
}
