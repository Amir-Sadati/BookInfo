using AutoMapper;
using BookInfo.Application.ViewModels.BookDto;
using BookInfo.Application.ViewModels.BookViewModel;
using BookInfo.Application.ViewModels.CommentViewModel;
using BookInfo.Application.ViewModels.UserViewModel;
using BookInfo.Domain.Entities;
using BookInfo.Domain.Entities.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Application.Automapper
{
   public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
             CreateMap<BookAuthor, authorbookdto>();
            CreateMap<Book, BookWithAuthorsDto>();
            CreateMap<Book, BookCreateViewModel>().ReverseMap();
            CreateMap<BookEditViewModel, Book>();
            CreateMap<Book, BooksPageListViewModel>();
            CreateMap<UserViewModel, AppUser>();
            CreateMap<UserEditViewModel, AppUser>();
            CreateMap<CreateCommentViewModel,Comment>();



            


            

          
            
          
            
          
           

               
        }
    }
}
