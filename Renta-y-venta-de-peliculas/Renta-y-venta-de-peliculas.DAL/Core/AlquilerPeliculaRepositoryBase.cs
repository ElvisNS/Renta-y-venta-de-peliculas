using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Renta_y_venta_de_peliculas.DAL.Context;


namespace Renta_y_venta_de_peliculas.DAL.Core
{
    public abstract class AlquilerPeliculaRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly RYPContext rYPContext;
        private DbSet<TEntity> myEntity;
        public AlquilerPeliculaRepositoryBase(RYPContext rYPContext)
        {
            this.rYPContext = rYPContext;
            this.myEntity = this.rYPContext.Set<TEntity>();
        }
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.myEntity.Any(filter);
        }
        public virtual List<TEntity> GetEntities()
        {
            return this.myEntity.ToList();
        }
        public virtual TEntity GetEntity(int id)
        {
            return this.myEntity.Find(id);
        }
        public virtual void Remove(TEntity entity)
        {
            this.myEntity.Remove(entity);
        }
        public virtual void Remove(TEntity[] entities)
        {
            this.myEntity.RemoveRange(entities);
        }
        public virtual void Save(TEntity entity)
        {
            this.myEntity.Add(entity);
        }
        public virtual void Save(TEntity[] entities)
        {
            this.myEntity.AddRange(entities);
        }
        public virtual void SaveChanges()
        {
            this.rYPContext.SaveChanges();
        }
        public virtual void Update(TEntity entity)
        {
            this.myEntity.Update(entity);
        }
        public virtual void Update(TEntity[] entities)
        {
            this.myEntity.UpdateRange(entities);
        }
    }
}
