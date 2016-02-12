using ContactManagement.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactManagement.Data.Repository
{
    public abstract class BaseMockRestRepository<TEntity, TKey> : IRestRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
    {
        public static IList<TEntity> Entities;

        public virtual TEntity Get(TKey id)
        {
            return this.GetAll()
                .SingleOrDefault(e => e.Identity.Equals(id));
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public virtual void Put(TEntity entity)
        {
            var old = this.Get(entity.Identity);
            if (old == null)
                throw new InvalidOperationException("Cannot Put an entity that does not already exist");

            Entities.Remove(old);
            Entities.Add(entity);
        }

        public virtual TEntity Post(TEntity entity)
        {
            Entities.Add(entity);
            return entity;
        }

        public virtual bool Delete(TEntity entity)
        {
            //Checking if entity already exists
            var old = this.Get(entity.Identity);
            if (old == null)
                throw new InvalidOperationException("Cannot Delete an entity that does not already exist");
            Entities.Remove(old);
            return true;
        }
    }
}