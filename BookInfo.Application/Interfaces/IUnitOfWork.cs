using BookInfo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.Interfaces
{
   public interface IUnitOfWork
    {
        Task<bool> Complete();
        IBookRepository bookRepository { get; }
        IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class;
    }
}
