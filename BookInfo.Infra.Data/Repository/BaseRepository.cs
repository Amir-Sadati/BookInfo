using BookInfo.Domain.Interfaces;
using BookInfo.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Infra.Data.Repository
{
   public class BaseRepository<TEntity> :IBaseRepository<TEntity> where TEntity:class
    {
        private readonly DataContext _context;
        private readonly DbSet<TEntity> _dbset;

        public BaseRepository(DataContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllEntities() =>
          await _dbset.AsNoTracking().ToListAsync();
       
        public async Task<TEntity> FindByIdAsync(Object id)=>await _dbset.FindAsync(id);
        
          
        
        public async Task AddAsync(TEntity entity) => await _dbset.AddAsync(entity);
        public void Remove(TEntity entity) => _dbset.Remove(entity);
        public void Update(TEntity entity) => _dbset.Update(entity);
       public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
            => await _dbset.AddRangeAsync(entities);

        public void UpdateRange(IEnumerable<TEntity> entities) => _dbset.UpdateRange(entities);

        public void RemoveRange(IEnumerable<TEntity> entities) => _dbset.RemoveRange(entities);

      




    }
}
