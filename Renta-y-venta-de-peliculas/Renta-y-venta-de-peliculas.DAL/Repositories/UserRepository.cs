using Microsoft.Extensions.Logging;
using Renta_y_venta_de_peliculas.DAL.Context;
using Renta_y_venta_de_peliculas.DAL.Entities;
using Renta_y_venta_de_peliculas.DAL.Exceptions;
using Renta_y_venta_de_peliculas.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Renta_y_venta_de_peliculas.DAL.Repositories
{
    public class UserRepository : Core.RepositoryBase<User>, IUserRepository
    {
        private readonly RYPContext rYPContext;
        private readonly ILogger<UserRepository> iloger;

        public UserRepository(RYPContext rYPContext, 
                        ILogger<UserRepository> iloger) : base(rYPContext) 
        {
            this.rYPContext = rYPContext;
            this.iloger = iloger;
        }
        public override List<User> GetEntities()
        {
            return this.rYPContext.user.Where(us => !us.Deleted).OrderByDescending(cd => cd.CreationDate).ToList();
        }
        public override void Save(User entity)
        {
            if(this.Exists(us => us.txt_nombre == entity.txt_nombre)) 
            {
                throw new UserDataExceptions("Este Usuario ya existe");
            }
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(User entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(User entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
    }
}
