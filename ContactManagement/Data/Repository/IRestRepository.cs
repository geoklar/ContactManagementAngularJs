using ContactManagement.Data.Entity;
using System.Linq;

namespace ContactManagement.Data.Repository
{
    public interface IRestRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
    {
        TEntity Get(TKey id);

        IQueryable<TEntity> GetAll();

        void Put(TEntity entity);

        TEntity Post(TEntity entity);

        bool Delete(TEntity entity);
    }
}