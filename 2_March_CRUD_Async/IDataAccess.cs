using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_March_CRUD_Async
{
    internal interface IDataAccess<TEntity, in TPk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task CreateAsync(TEntity entity);
        Task<int> UpdateAsync(TPk id, TEntity entity);
        Task<int> DeleteAsync(TPk id);
        Task<TEntity> GetAsync(TPk id);
    }
}
