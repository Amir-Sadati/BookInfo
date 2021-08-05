using BookInfo.Domain.Entities;
using BookInfo.Domain.Entities.Identities;
using BookInfo.Infra.Data.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Infra.Data.Context
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole,
        IdentityUserLogin<int>, AppRoleClaim, IdentityUserToken<int>>
    {

        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.AddCustomBookInfoMapping();
            builder.AddCustomIdentityMapping();

        }

        public DbSet<Author> Author { set; get; }
        public DbSet<Book> Book { set; get; }
        public DbSet<BookAuthor> BookAuthor { set; get; }
        public DbSet<BookCategory> BookCategory { set; get; }
        public DbSet<Category> Category { set; get; }
        public DbSet<City> City { set; get; }
        public DbSet<Comment> Comment { set; get; }
        public DbSet<Photo> Photo { set; get; }
        public DbSet<Province> Province { set; get; }
        public DbSet<Publisher> Publisher { set; get; }






    }
}
