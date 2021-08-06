using AutoMapper;
using BookInfo.Application.Interfaces;
using BookInfo.Application.ViewModels.BookViewModel;
using BookInfo.Domain.Classes;
using BookInfo.Domain.Entities;

using BookInfo.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Api.Controllers.BookApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
       
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public BookController(IUnitOfWork unitofwork  , IMapper mapper)
        {
             
            _unitofwork = unitofwork;
            _mapper = mapper;
        }

        [HttpGet("GetBooksList")]
        public async Task<PagedList<BooksPageListViewModel>> GetBooksList([FromQuery] PaginationParams pageparams)
        {
           return await _unitofwork.bookRepository.GetBooksList(pageparams);
        }

        [HttpGet("GetBookInfo/{BookId}")]
        public async Task<ActionResult<BookInfoViewModel>> GetBookInfo(int BookId)
        {
            if (_unitofwork.BaseRepository<Book>().FindById(BookId) == null)
                return BadRequest("کتاب مورد نظر یافت نشد");

          return Ok(await _unitofwork.bookRepository.GetBookInfo(BookId));

        }
           
         
           
       

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(BookCreateViewModel viewmodel)
        {
            
                await _unitofwork.bookRepository.CreateBookAsync(viewmodel);

            if (await _unitofwork.Complete() != true)
                return BadRequest("خطایی رخ داده است");
                return Ok("با موفقیت ثبت شد");
           
           

           
        }

        [HttpDelete("DeleteBook/{BookId}")]
        public async Task<IActionResult> DeleteBook(int BookId)
        {
            var book =  _unitofwork.BaseRepository<Book>().FindById(BookId);
            if (book == null) return NotFound();

            _unitofwork.BaseRepository<Book>().Remove(book);
           await _unitofwork.Complete();
            return Ok("با موفقیت حذف شد");
        }

        [HttpPut("EditBook")]
        public async Task<ActionResult<BookEditViewModel>> EditBook(BookEditViewModel viewmodel)
        {
            var RecentBook =  _unitofwork.BaseRepository<Book>().FindById(viewmodel.BookId);
            if (RecentBook == null)
                return NotFound();
            var editedbook=await _unitofwork.bookRepository.EditBook(viewmodel, RecentBook);
            await _unitofwork.Complete();

            return editedbook;
        }

        #region ShowAauthorsBook in Some Way

        //way one : with Automapper 
        [HttpGet("{bookId}")]
        public async Task<IActionResult> Showauthorsbook(int bookId)
        {
            if ( _unitofwork.BaseRepository<Book>().FindById(bookId) == null)
                return NotFound();
           
           return  Ok(await _unitofwork.bookRepository.GetBookWithAuthorsAsync(bookId));
           
        }

       

        //way two : 

        [HttpGet("getauthor/{bookid}")]
        public async Task<IActionResult> GetAuthorsBook(int bookid)
        {
             if ( _unitofwork.BaseRepository<Book>().FindById(bookid) == null)
                return NotFound();
            return Ok(await _unitofwork.bookRepository.GetAuthorAsync(bookid));
        }
        #endregion

    }
}
