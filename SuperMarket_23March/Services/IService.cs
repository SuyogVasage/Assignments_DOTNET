using System.Collections.Generic;

namespace SuperMarket_23March.Services
{
    public interface IService<TEntity, U> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(U id);
        bool Create(TEntity entity);
        bool Update(U id, TEntity entity);
        bool Delete(U id);
    }
}
