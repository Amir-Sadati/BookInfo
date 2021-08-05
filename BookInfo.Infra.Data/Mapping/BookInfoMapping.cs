using BookInfo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Infra.Data.Mapping
{
    public static class BookInfoMapping
    {
        public static void AddCustomBookInfoMapping (this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<BookCategory>(new BookCategoryMapping ());
            modelBuilder.ApplyConfiguration<BookAuthor>(new BookAuthorMapping ());

        }
    }
}
