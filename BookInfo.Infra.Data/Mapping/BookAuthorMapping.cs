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
    public class BookAuthorMapping : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(x => new { x.AuthorId, x.BookId });
            builder.HasOne(x => x.Book).WithMany(x => x.BookAuthors);
            builder.HasOne(x => x.Author).WithMany(x => x.BookAuthors);

        }
    }
}
