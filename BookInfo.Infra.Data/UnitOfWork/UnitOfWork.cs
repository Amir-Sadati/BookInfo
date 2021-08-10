using AutoMapper;
using BookInfo.Application.Interfaces;
using BookInfo.Domain.Interfaces;
using BookInfo.Infra.Data.Context;
using BookInfo.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private IBookRepository _bookRepository;
        private ICommentsRepository _commentRepository;


        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IBookRepository bookRepository
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository(_context, _mapper);
                return _bookRepository;
            }

        }
        public ICommentsRepository commentRepository
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_context);
                return _commentRepository;
            }

        }

        public IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class
        {
            IBaseRepository<TEntity> baserepository = new BaseRepository<TEntity>(_context);
            return baserepository;
        }




        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
