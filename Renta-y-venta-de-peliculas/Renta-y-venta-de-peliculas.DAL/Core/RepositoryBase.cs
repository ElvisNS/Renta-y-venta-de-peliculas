using Microsoft.EntityFrameworkCore;
using Renta_y_venta_de_peliculas.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Renta_y_venta_de_peliculas.DAL.Core
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly RYPContext context;
        private DbSet<TEntity> myEntity;
        public RepositoryBase(RYPContext context)
        {
            this.context = context;
            this.myEntity = this.context.Set<TEntity>();
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
            this.context.SaveChanges();
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
