using BookInfo.Domain.Entities.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Infra.Data.Mapping
{
   public static class IdentityMapping
    {
        public static void AddCustomIdentityMapping(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().ToTable("AppUsers");
            modelBuilder.Entity<AppRole>().ToTable("AppRoles");
            modelBuilder.Entity<AppUserRole>().ToTable("AppUserRole");
            modelBuilder.Entity<AppRoleClaim>().ToTable("AppRoleClaim");
            modelBuilder.Entity<AppUserClaim>().ToTable("AppUserClaim");

            modelBuilder.Entity<AppUserRole>()
                .HasOne(x => x.AppRole)
                .WithMany(x => x.AppUserRoles).HasForeignKey(x => x.RoleId).IsRequired();

            modelBuilder.Entity<AppUserRole>()
               .HasOne(x => x.AppUser)
               .WithMany(x => x.AppUserRoles).HasForeignKey(x => x.UserId).IsRequired();

            modelBuilder.Entity<AppRoleClaim>()
                 .HasOne(x => x.Approle)
                 .WithMany(x => x.AppClaims).HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<AppUserClaim>()
                .HasOne(x=>x.AppUser)
                .WithMany(x=>x.AppClaims).HasForeignKey(x=>x.UserId);
        }
    }
}
