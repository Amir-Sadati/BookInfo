using BookInfo.Application.ViewModels.BookDto;
using BookInfo.Application.ViewModels.BookViewModel;
using BookInfo.Domain.Classes;
using BookInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.Interfaces
{
        public interface IBookRepository
    {
        Task<BookWithAuthorsDto> GetBookWithAuthorsAsync(int BookId);
        Task<BookAuthorsViewModel> GetAuthorAsync(int BookId);
        Task CreateBookAsync(BookCreateViewModel viewModel);
        Task<BookEditViewModel> EditBook(BookEditViewModel viewmodel, Book Recentbook);
        Task<PagedList<BooksPageListViewModel>> GetBooksList(PaginationParams pageparams);

    }
}
