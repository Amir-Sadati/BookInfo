using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookInfo.Application.Interfaces;
using BookInfo.Application.ViewModels.BookDto;
using BookInfo.Application.ViewModels.BookViewModel;
using BookInfo.Domain.Classes;
using BookInfo.Domain.Entities;
using BookInfo.Domain.Interfaces;

using BookInfo.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Infra.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookWithAuthorsDto> GetBookWithAuthorsAsync(int BookId)
        {

            return await _context.Book.Where(x => x.BookId == BookId).ProjectTo<BookWithAuthorsDto>
                  (_mapper.ConfigurationProvider).SingleOrDefaultAsync();

        }

        public async Task<BookEditViewModel> EditBook(BookEditViewModel viewmodel, Book Recentbook)
        {





            if (viewmodel.AuthorId == null)
                viewmodel.AuthorId = new List<int>();
            if (viewmodel.CategroyId == null)
                viewmodel.CategroyId = new List<int>();

            var RecentAuthorId = _context.BookAuthor.Where(x => x.BookId == viewmodel.BookId)
                .Select(x => x.AuthorId).ToList();
            var NewAuthorId = viewmodel.AuthorId.Except(RecentAuthorId);
            var DeletedAuthorId = RecentAuthorId.Except(viewmodel.AuthorId);

            var RecentCategoreisId = _context.BookCategory.Where(x => x.BookId == viewmodel.BookId)
                .Select(x => x.CategoryId).ToList();
            var NewCategoryId = viewmodel.CategroyId.Except(RecentCategoreisId);
            var DeletedCategoryId = RecentCategoreisId.Except(viewmodel.CategroyId);


            if (NewAuthorId.Count() > 0)
                await _context.BookAuthor.AddRangeAsync
                     (NewAuthorId.Select(x => new BookAuthor { AuthorId = x, BookId = viewmodel.BookId }));
            if (DeletedAuthorId.Count() > 0)
                _context.BookAuthor.RemoveRange
                   (DeletedAuthorId.Select(x => new BookAuthor { AuthorId = x, BookId = viewmodel.BookId }));
            if (NewCategoryId.Count() > 0)
                await _context.BookCategory.AddRangeAsync
                     (NewCategoryId.Select(x => new BookCategory { CategoryId = x, BookId = viewmodel.BookId }));
            if (DeletedCategoryId.Count() > 0)
                _context.BookCategory.RemoveRange
                    (DeletedCategoryId.Select(x => new BookCategory { CategoryId = x, BookId = viewmodel.BookId }));

            var editbook = _mapper.Map(viewmodel, Recentbook);
            if (viewmodel.IsPublish == true && Recentbook.IsPublish == false)
            {
                Recentbook.PublishDate = DateTime.Now;
            }
            else if (viewmodel.IsPublish == false && Recentbook.IsPublish == true)
            {
                Recentbook.PublishDate = null;
            }

            else
            {
                Recentbook.PublishDate = Recentbook.PublishDate;
            }
            _context.Book.Update(editbook);
            return viewmodel;

        }

        public async Task<BookAuthorsViewModel> GetAuthorAsync(int BookId)
        {
            return await _context.Book.Where(x => x.BookId == BookId)
           .Select(x => new BookAuthorsViewModel
           { Name = x.BookName, Authors = x.BookAuthors.Select(x => x.Author.Name + " " + x.Author.Family).ToList() })
            .SingleOrDefaultAsync();

        }

        public async Task<PagedList<BooksPageListViewModel>> GetBooksList(PaginationParams pageparams)
        {
            var AllItem = _context.Book.ProjectTo<BooksPageListViewModel>(_mapper.ConfigurationProvider);

            var specificItem = await PagedList<BooksPageListViewModel>
                  .CreateAsync(AllItem, pageparams.PageNumber, pageparams.PageSize);



            var rows = (pageparams.PageSize * (pageparams.PageNumber - 1));
            foreach (var item in specificItem)
            {
                item.Row = ++rows;
            }
            return specificItem;









        }


        public async Task CreateBookAsync(BookCreateViewModel viewModel)
        {

            Book book = new Book();
            var bookmap = _mapper.Map(viewModel, book);

            if (viewModel.AuthorsId != null)
            {
                book.BookAuthors = viewModel.AuthorsId
              .Select(x => new BookAuthor { AuthorId = x }).ToList();
            }

            if (viewModel.CategoriesId != null)
            {
                book.BookCategories = viewModel.CategoriesId
              .Select(x => new BookCategory { CategoryId = x }).ToList();
            }


            await _context.Book.AddAsync(book);

        }



    }
}
