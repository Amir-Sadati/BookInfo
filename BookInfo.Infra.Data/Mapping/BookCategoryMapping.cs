using BookInfo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Infra.Data.Mapping
{
    public class BookCategoryMapping : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(x => new { x.BookId, x.CategoryId });
            builder.HasOne(x => x.Book).WithMany(x => x.BookCategories);
            builder.HasOne(x => x.Book).WithMany(x => x.BookCategories);
           

        }
    }
}
