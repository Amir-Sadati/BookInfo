using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetAllEntities();
        TEntity FindById(Object id);
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        void UpdateRange(IEnumerable<TEntity> entities);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
